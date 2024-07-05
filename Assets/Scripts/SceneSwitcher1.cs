using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;
    public Vector3 playerStartPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetPlayerStartPosition(playerStartPosition);
            SceneManager.LoadScene(sceneName);
        }
    }
}
