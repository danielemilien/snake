using UnityEngine;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
    // const settings
    public int startingSize = 5;
    public float moveInterval = 0.25f;

    [SerializeField]
    private GameObject bodyPrefab;
    private Queue<GameObject> snake = new Queue<GameObject>();
    private Vector3 headPosition = new Vector3(-0.5f, -0.5f, 0);
    private float moveTimer = 0;
    private Vector3 lastMoveDir = Vector3.zero;
    private Vector3 moveDir = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // loop backwards to put head at front of queue
        for (int i = startingSize - 1; i >= 0; i--)
        {
            snake.Enqueue(Instantiate(bodyPrefab, headPosition + (i * Vector3.left), Quaternion.identity));
        }
        moveTimer = moveInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // kb input -> movement direction
        // can't move in opposite direction of current movement
        if (Input.GetKeyDown(KeyCode.UpArrow) && lastMoveDir != Vector3.down)
        {
            moveDir = Vector3.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && lastMoveDir != Vector3.up)
        {
            moveDir = Vector3.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && lastMoveDir != Vector3.right)
        {
            moveDir = Vector3.left;
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && lastMoveDir != Vector3.left)
        {
            moveDir = Vector3.right;
        }

        // move if it's time
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0) {
            // update fields
            lastMoveDir = moveDir;
            headPosition += moveDir;

            // remove body segment from back, add to front in correct direction
            GameObject tail = snake.Dequeue();
            Destroy(tail);
            snake.Enqueue(Instantiate(bodyPrefab, headPosition, Quaternion.identity));

            // reset timer
            moveTimer = moveInterval;
        }
    }
}
