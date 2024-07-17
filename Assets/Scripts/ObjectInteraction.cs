using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject questionPanel; // 질문을 표시할 패널
    public TextMeshProUGUI questionText; // 질문 텍스트
    public TMP_InputField answerInputField; // 대답을 입력받을 인풋 필드

    private bool isAnsweringQuestion = false; // 질문에 답변 중인지 여부

    void Start()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(false); // 시작 시 질문 패널을 숨깁니다.
        }
    }

    void Update()
    {
        if (isAnsweringQuestion && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(); // Enter 키를 눌렀을 때 정답을 확인합니다.
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Interacting with desk. Press E to answer the question.");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Desk") && Input.GetKeyDown(KeyCode.E))
        {
            StartQuestion(); // E 키를 눌렀을 때 질문을 시작합니다.
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Stopped interacting with desk.");
            if (questionPanel != null)
            {
                questionPanel.SetActive(false); // 떠날 때 질문 패널을 숨깁니다.
            }
            isAnsweringQuestion = false; // 질문에 대한 답변 상태를 해제합니다.
        }
    }

    void StartQuestion()
    {
        if (questionPanel != null)
        {
            // 여기서 질문을 설정하고 패널을 활성화합니다.
            questionText.text = "What is the capital of France?";
            questionPanel.SetActive(true);
            answerInputField.text = ""; // 입력 필드 초기화
            answerInputField.Select(); // 입력 필드 선택
            isAnsweringQuestion = true; // 질문에 답변 중임을 설정합니다.
        }
    }

    void CheckAnswer()
    {
        if (answerInputField != null)
        {
            string userAnswer = answerInputField.text.Trim().ToLower(); // 사용자 입력을 소문자로 변환하여 공백 제거
            if (userAnswer == "paris")
            {
                Debug.Log("Correct answer!");
                // 여기에 정답일 때의 처리를 추가합니다.
                questionPanel.SetActive(false); // 질문 패널 숨기기
                isAnsweringQuestion = false; // 답변 중 상태 해제
            }
            else
            {
                Debug.Log("Wrong answer. Try again.");
                // 여기에 오답일 때의 처리를 추가합니다. (예를 들어 다시 질문하거나 재입력 요청 등)
            }
        }
    }
}
