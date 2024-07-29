using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public string message; // 표시할 메시지
    public GameObject messageBox; // 메시지 박스
    public TextMeshProUGUI messageText; // 메시지 텍스트
    public string correctAnswer; // 정답
    public string nextSceneName = "#2.HomeYard"; // 다음 씬 이름
    public TMP_InputField answerInputField; // 사용자의 입력을 받는 InputField
    public GameObject sceneTrigger; // 씬 트리거 오브젝트
    private bool isAnswerCorrect = false; // 정답 여부
    public Transform playerTransform; // 주인공의 Transform

    void Start()
    {
        HideMessage();
        if (sceneTrigger != null)
        {
            sceneTrigger.SetActive(false); // 초기에는 씬 트리거를 비활성화합니다.
        }
    }

    public void CheckAnswer()
    {
        if (answerInputField != null)
        {
            string userAnswer = answerInputField.text.Trim();
            if (string.Equals(userAnswer, correctAnswer, System.StringComparison.OrdinalIgnoreCase))
            {
                isAnswerCorrect = true;
            }
            else
            {
                isAnswerCorrect = false;
            }
        }
    }

    void Update()
    {
        if (isAnswerCorrect && Input.GetKeyDown(KeyCode.E))
        {
            ShowMessage("문이 열렸습니다.");
            if (sceneTrigger != null)
            {
                sceneTrigger.SetActive(true); // 씬 트리거를 활성화합니다.
            }
        }
    }

    public void ShowMessage(string msg)
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = msg;
            messageBox.SetActive(true);
        }
    }

    public void HideMessage()
    {
        if (messageBox != null)
        {
            messageBox.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 주인공의 현재 위치 저장
            GameManager1.Instance.SetPlayerStartPosition(playerTransform.position);
            LoadNextScene(nextSceneName);
        }
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
