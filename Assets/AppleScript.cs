using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public GameObject gameManager;

    private int spawnAreaWidth;
    private int spawnAreaHeight;

    void Start()
    {
        spawnAreaWidth = gameManager.GetComponent<GameManagerScript>().playAreaWidth - 1;
        spawnAreaHeight = gameManager.GetComponent<GameManagerScript>().playAreaHeight - 1;
    }

    public void reposition(GameObject[] snake)
    {
        bool validPosition = false;
        while (!validPosition)
        {
            transform.position = new Vector3(
                (int)Random.Range(-spawnAreaWidth/2, spawnAreaWidth / 2), 
                (int)Random.Range(-spawnAreaHeight/2, spawnAreaHeight / 2), 
                0);
            foreach (GameObject segment in snake)
            {
                if (transform.position != segment.transform.position)
                {
                    validPosition = true;
                } else
                {
                    validPosition = false; 
                    break;
                }
            }
        }
    }
}
