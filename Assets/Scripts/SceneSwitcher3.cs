using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher3 : MonoBehaviour
{
    public string sceneName;
    public Vector3 playerStartPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager3.Instance != null)
            {
                GameManager3.Instance.SetPlayerStartPosition(playerStartPosition);
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("GameManager3.Instance is null. Make sure GameManager3 script is properly initialized.");
            }
        }
    }
}
