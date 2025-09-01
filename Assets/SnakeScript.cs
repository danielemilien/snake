using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;

public class SnakeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bodyPrefab;
    private Queue<GameObject> snake = new Queue<GameObject>();
    private float moveTimer = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newBody = Instantiate(bodyPrefab, new Vector3((float)(-0.5 - i), (float)(-0.5), 0), Quaternion.identity);
            snake.Enqueue(newBody);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0) {
            foreach (GameObject item in snake)
            {
                item.transform.position += new Vector3(1, 0, 0);
            }
            moveTimer = 0.5f;
        }
    }
}
