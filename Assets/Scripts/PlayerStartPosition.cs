using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = GameManager.Instance.GetPlayerStartPosition();
        }
    }
}
