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
            if (GameManager1.Instance != null)
            {
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
