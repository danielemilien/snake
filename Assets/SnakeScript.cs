using UnityEngine;
using System.Collections.Generic;

public class SnakeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bodyPrefab;
    private Queue<GameObject> snake = new Queue<GameObject>();
    private Vector3 headPosition = new Vector3(-0.5f, -0.5f, 0);
    private float moveTimer = 0.25f;
    private Vector3 moveDir = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // loop backwards to put head at front of queue
        for (int i = 2; i >= 0; i--)
        {
            snake.Enqueue(Instantiate(bodyPrefab, headPosition + (i * Vector3.left), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // kb input -> movement direction
        if (Input.GetKeyDown(KeyCode.UpArrow) && moveDir != Vector3.down)
        {
            moveDir = Vector3.up;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && moveDir != Vector3.up)
        {
            moveDir = Vector3.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && moveDir != Vector3.right)
        {
            moveDir = Vector3.left;
        } else if(Input.GetKeyDown(KeyCode.RightArrow) && moveDir != Vector3.left)
        {
            moveDir = Vector3.right;
        }

        // move if it's time
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0) {
            headPosition += moveDir;
            GameObject tail = snake.Dequeue();
            Destroy(tail);
            snake.Enqueue(Instantiate(bodyPrefab, headPosition, Quaternion.identity));
            moveTimer = 0.25f;
        }
    }
}
