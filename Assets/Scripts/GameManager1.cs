using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance { get; private set; }

    private Vector3 playerStartPosition;
    private GameObject player;

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerStartPosition;
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
}
