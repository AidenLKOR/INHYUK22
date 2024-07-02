using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad;
    public Vector3 playerStartPositionInNextScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // GameManager �ν��Ͻ��� null�� �ƴ��� Ȯ��
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetPlayerStartPosition(playerStartPositionInNextScene);
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("GameManager.Instance is null. Make sure GameManager is added to the scene.");
            }
        }
    }
}
