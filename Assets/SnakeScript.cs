using UnityEngine;
using System.Collections.Generic;
public class SnakeScript : MonoBehaviour
{
    // const settings
    public int startingSize = 5;
    public float moveInterval = 0.25f;

    // references passed throgh inspector
    [SerializeField]
    private GameObject bodyPrefab;
    public GameObject apple;

    private Queue<GameObject> snake;
    private Vector3 headPosition;
    private float moveTimer;
    private Vector3 lastMoveDir;
    private Vector3 moveDir;
    private bool dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // field initializtion
        snake = new Queue<GameObject>();
        headPosition = Vector3.zero;
        lastMoveDir = Vector3.zero;
        moveDir = Vector3.right;
        dead = false;
        moveTimer = moveInterval;

        // loop backwards to put head at front of queue
        for (int i = startingSize - 1; i >= 0; i--)
        {
            snake.Enqueue(Instantiate(bodyPrefab, headPosition + (i * Vector3.left), Quaternion.identity));
        }

        // set initial apple position
        apple.GetComponent<AppleScript>().reposition(snake.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        // dont do anything if dead
        if (dead) return;

        // kb input -> movement direction
        // can't move in opposite direction of current movement
        if (Input.GetKeyDown(KeyCode.UpArrow) && lastMoveDir != Vector3.down && lastMoveDir != Vector3.up)
        {
            moveDir = Vector3.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && lastMoveDir != Vector3.up && lastMoveDir != Vector3.down)
        {
            moveDir = Vector3.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && lastMoveDir != Vector3.right && lastMoveDir != Vector3.left)
        {
            moveDir = Vector3.left;
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && lastMoveDir != Vector3.left && lastMoveDir != Vector3.right)
        {
            moveDir = Vector3.right;
        }

        // move if it's time
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0) {
            // update fields
            lastMoveDir = moveDir;
            headPosition += moveDir;

            // add new head
            snake.Enqueue(Instantiate(bodyPrefab, headPosition, Quaternion.identity));

            // if collected apple reposition it and extend snake
            if (headPosition == apple.transform.position)
            {
                apple.GetComponent<AppleScript>().reposition(snake.ToArray());
            } else
            {
                Destroy(snake.Dequeue());
            }

            // die if snake runs into itself
            GameObject[] snakeArray = snake.ToArray();
            for (int i = 0; i < snake.Count - 1; i++)
            {
                // end at len - 1 to avoid comparing head to itself
                if (snakeArray[i].transform.position == headPosition)
                {
                    dead = true;
                    break;
                }
            }

            // reset move timer
            moveTimer = moveInterval;
        }

    }
}
