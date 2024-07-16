using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public MiniGameManager miniGameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Interacting with desk. Press E to start the mini-game.");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Desk") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Starting mini-game.");
            miniGameManager.StartMiniGame();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Stopped interacting with desk.");
        }
    }
}
