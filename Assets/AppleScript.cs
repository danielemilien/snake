using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public void reposition(GameObject[] snake)
    {
        bool validPosition = false;
        while (!validPosition)
        {
            transform.position = new Vector3((int)Random.Range(-10, 11), (int)Random.Range(-10, 11), 0);
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
