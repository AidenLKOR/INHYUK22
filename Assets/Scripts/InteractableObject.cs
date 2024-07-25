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

    void Start()
    {
        Debug.Log("Start 메서드 호출됨");
        Debug.Log("Message Box: " + (messageBox != null));
        Debug.Log("Message Text: " + (messageText != null));
        Debug.Log("Answer Input Field: " + (answerInputField != null));
        Debug.Log("Correct Answer: " + correctAnswer);
        Debug.Log("Next Scene Name: " + nextSceneName);

        HideMessage();
        if (sceneTrigger != null)
        {
            sceneTrigger.SetActive(false); // 초기에는 씬 트리거를 비활성화합니다.
        }
    }

    public void CheckAnswer()
    {
        Debug.Log("CheckAnswer 메서드 호출됨");
        if (answerInputField != null)
        {
            string userAnswer = answerInputField.text.Trim();
            Debug.Log("사용자 입력: " + userAnswer);
            if (string.Equals(userAnswer, correctAnswer, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("정답입니다.");
                isAnswerCorrect = true;
            }
            else
            {
                Debug.Log("틀렸습니다. 다시 시도하세요.");
                isAnswerCorrect = false;
            }
        }
        else
        {
            Debug.LogError("answerInputField가 설정되지 않았습니다.");
        }
    }

    void Update()
    {
        if (isAnswerCorrect && Input.GetKeyDown(KeyCode.E))
        {
            ShowMessage("문이 열렸습니다."); // 메시지를 전달합니다.
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
        else
        {
            Debug.LogWarning("Trying to access destroyed object in ShowMessage method.");
        }
    }

    public void HideMessage()
    {
        if (messageBox != null)
        {
            messageBox.SetActive(false);
        }
    }
}
