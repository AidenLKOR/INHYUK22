using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = GameManager1.Instance.GetPlayerStartPosition();
        }
        else
        {
            Debug.LogError("Player not found in the scene.");
        }
    }
}
