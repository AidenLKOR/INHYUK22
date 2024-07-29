using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance { get; private set; }
    private Vector3 playerStartPosition = Vector3.zero; // 기본값 설정

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("GameManager1 initialized and sceneLoaded event added.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerStartPosition(Vector3 position)
    {
        playerStartPosition = position;
        Debug.Log("Player start position set to: " + position);
    }

    public Vector3 GetPlayerStartPosition()
    {
        Debug.Log("Getting player start position: " + playerStartPosition);
        return playerStartPosition;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Debug.Log("Setting player position to: " + playerStartPosition);
            player.transform.position = playerStartPosition;
        }
        else
        {
            Debug.LogError("Player not found in the scene: " + scene.name);
        }
    }
}
