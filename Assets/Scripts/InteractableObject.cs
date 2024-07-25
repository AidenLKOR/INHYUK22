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

    void Start()
    {
        Debug.Log("Start 메서드 호출됨");
        Debug.Log("Message Box: " + (messageBox != null));
        Debug.Log("Message Text: " + (messageText != null));
        Debug.Log("Answer Input Field: " + (answerInputField != null));
        Debug.Log("Correct Answer: " + correctAnswer);
        Debug.Log("Next Scene Name: " + nextSceneName);

        HideMessage();
    }

    public void ShowMessage()
    {
        if (messageBox != null && messageText != null)
        {
            messageText.text = message;
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

    public void CheckAnswer()
    {
        Debug.Log("CheckAnswer 메서드 호출됨");
        if (answerInputField != null)
        {
            string userAnswer = answerInputField.text;
            Debug.Log("사용자 입력: " + userAnswer);
            if (userAnswer == correctAnswer)
            {
                Debug.Log("정답입니다. 씬을 전환합니다.");
                LoadNextScene(nextSceneName);
            }
            else
            {
                Debug.Log("틀렸습니다. 다시 시도하세요.");
            }
        }
        else
        {
            Debug.LogError("answerInputField가 설정되지 않았습니다.");
        }
    }

    public void LoadNextScene(string sceneName)
    {
        Debug.Log("씬 전환 시도: " + sceneName);
        try
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("씬 전환 성공: " + sceneName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("씬 전환 실패: " + e.Message);
        }
    }
}
