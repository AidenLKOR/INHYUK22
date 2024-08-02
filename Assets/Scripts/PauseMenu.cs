using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 추가
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // 일시정지 상태창
    public GameObject quitConfirmationPanel; // 게임 종료 확인창
    public GameObject missionPanel; // 미션 창
    public TextMeshProUGUI missionText; // 미션 텍스트

    public Button resumeButton; // 돌아가기 버튼
    public Button quitButton; // 게임 종료 버튼
    public Button confirmQuitButton; // '네' 버튼
    public Button cancelQuitButton; // '아니오' 버튼
    public Button missionButton; // 미션 버튼
    public Button closeMissionButton; // 미션 창 닫기 버튼

    private bool isPaused = false;

    void Start()
    {
        // 상태창과 확인창을 숨깁니다.
        pausePanel.SetActive(false);
        quitConfirmationPanel.SetActive(false);
        missionPanel.SetActive(false);

        // 버튼에 이벤트 리스너를 추가합니다.
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(ShowQuitConfirmation);
        confirmQuitButton.onClick.AddListener(QuitGame);
        cancelQuitButton.onClick.AddListener(CancelQuit);
        missionButton.onClick.AddListener(ShowMission);
        closeMissionButton.onClick.AddListener(CloseMission);
    }

    void Update()
    {
        // ESC 키를 눌렀을 때 상태창을 토글합니다.
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

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // 게임을 일시정지합니다.
        pausePanel.SetActive(true); // 상태창을 표시합니다.
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // 게임을 재개합니다.
        pausePanel.SetActive(false); // 상태창을 숨깁니다.
        quitConfirmationPanel.SetActive(false); // 확인창을 숨깁니다.
        missionPanel.SetActive(false); // 미션 창을 숨깁니다.
    }

    void ShowQuitConfirmation()
    {
        pausePanel.SetActive(false); // 상태창을 숨깁니다.
        quitConfirmationPanel.SetActive(true); // 확인창을 표시합니다.
    }

    void CancelQuit()
    {
        quitConfirmationPanel.SetActive(false); // 확인창을 숨깁니다.
        pausePanel.SetActive(true); // 상태창을 다시 표시합니다.
    }

    void ShowMission()
    {
        pausePanel.SetActive(false); // 상태창을 숨깁니다.
        missionPanel.SetActive(true); // 미션 창을 표시합니다.
    }

    void CloseMission()
    {
        missionPanel.SetActive(false); // 미션 창을 숨깁니다.
        pausePanel.SetActive(true); // 상태창을 다시 표시합니다.
    }

    void QuitGame()
    {
        Application.Quit(); // 게임을 종료합니다.
        // Unity 에디터에서 실행 중인 경우
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
