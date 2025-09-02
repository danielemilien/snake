using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int playAreaWidth = 20;
    public int playAreaHeight = 10;

    public GameObject borderPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject topBorder = Instantiate(borderPrefab, new Vector3(0, (int)(playAreaHeight / 2)), Quaternion.identity);
        topBorder.transform.localScale = new Vector3(playAreaWidth, 0.25f);

        GameObject bottomBorder = Instantiate(borderPrefab, new Vector3(0, (int)(-playAreaHeight / 2)), Quaternion.identity);
        bottomBorder.transform.localScale = new Vector3(playAreaWidth, 0.25f);

        GameObject leftBorder = Instantiate(borderPrefab, new Vector3((int)(-playAreaWidth / 2), 0), Quaternion.identity);
        leftBorder.transform.localScale = new Vector3(0.25f, playAreaHeight);

        GameObject rightBorder = Instantiate(borderPrefab, new Vector3((int)(playAreaWidth / 2), 0), Quaternion.identity);
        rightBorder.transform.localScale = new Vector3(0.25f, playAreaHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
