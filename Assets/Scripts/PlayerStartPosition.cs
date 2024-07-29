using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 startPosition = GameManager1.Instance.GetPlayerStartPosition();
            Debug.Log("Setting player position on start: " + startPosition);
            player.transform.position = startPosition;
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }
}
