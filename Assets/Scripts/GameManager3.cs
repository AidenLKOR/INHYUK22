using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 Instance { get; private set; }
    private Vector3 playerStartPosition;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    public void SetPlayerStartPosition(Vector3 position)
    {
        playerStartPosition = position;
    }

    public Vector3 GetPlayerStartPosition()
    {
        return playerStartPosition;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerStartPosition;
        }
    }
}
