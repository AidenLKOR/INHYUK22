using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher1 : MonoBehaviour
{
    public string sceneName;
    public Vector3 playerStartPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone. Loading scene: " + sceneName);
            if (GameManager1.Instance != null)
            {
                Debug.Log("Setting player start position to: " + playerStartPosition);
                GameManager1.Instance.SetPlayerStartPosition(playerStartPosition);
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("GameManager1.Instance is null. Make sure GameManager1 script is properly initialized.");
            }
        }
    }
}
