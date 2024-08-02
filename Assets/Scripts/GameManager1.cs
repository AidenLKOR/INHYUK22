using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance { get; private set; }

    private Vector3 playerStartPosition;
    private GameObject player;

    // PauseMenu 관련 필드 추가
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            // PauseMenuCanvas 프리팹을 인스턴스화하고 DontDestroyOnLoad를 적용합니다.
            if (pauseMenuPrefab != null && pauseMenuInstance == null)
            {
                pauseMenuInstance = Instantiate(pauseMenuPrefab);
                DontDestroyOnLoad(pauseMenuInstance);
                pauseMenuInstance.SetActive(false);
            }
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

        // PauseMenuCanvas가 없으면 생성
        if (pauseMenuInstance == null && pauseMenuPrefab != null)
        {
            pauseMenuInstance = Instantiate(pauseMenuPrefab);
            DontDestroyOnLoad(pauseMenuInstance);
            pauseMenuInstance.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
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

    public void PauseGame()
    {
        if (pauseMenuInstance != null)
        {
            pauseMenuInstance.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuInstance != null)
        {
            pauseMenuInstance.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
