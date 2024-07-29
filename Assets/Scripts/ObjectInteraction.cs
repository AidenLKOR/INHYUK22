using UnityEngine;
using TMPro;
using System.Collections;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject questionPanel; // 질문을 표시할 패널
    public TextMeshProUGUI questionText; // 질문 텍스트
    public TMP_InputField answerInputField; // 대답을 입력받을 인풋 필드
    public TextMeshProUGUI resultText; // 정답 및 오답 결과 텍스트
    public float interactionRadius = 2.0f; // 상호작용 반경
    public float resultDisplayTime = 2.0f; // 결과를 표시할 시간

    private bool isAnsweringQuestion = false; // 질문에 답변 중인지 여부
    private bool isNearDesk = false; // 플레이어가 Desk 근처에 있는지 여부

    void Start()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(false); // 시작 시 질문 패널을 숨깁니다.
        }
        if (resultText != null)
        {
            resultText.gameObject.SetActive(false); // 시작 시 결과 텍스트를 숨깁니다.
        }
    }

    void Update()
    {
        if (isAnsweringQuestion && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(); // Enter 키를 눌렀을 때 정답을 확인합니다.
        }

        // 상호작용 인식 범위 내에 있는지 확인합니다.
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Desk"))
            {
                isNearDesk = true;
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    StartQuestion(); // Q 키를 눌렀을 때 질문을 시작합니다.
                }
            }
            else
            {
                isNearDesk = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Interacting with desk. Press Q to answer the question.");
            isNearDesk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Desk"))
        {
            Debug.Log("Stopped interacting with desk.");
            isNearDesk = false;
            if (questionPanel != null)
            {
                questionPanel.SetActive(false); // 떠날 때 질문 패널을 숨깁니다.
            }
            if (resultText != null)
            {
                resultText.gameObject.SetActive(false); // 떠날 때 결과 텍스트를 숨깁니다.
            }
            isAnsweringQuestion = false; // 질문에 대한 답변 상태를 해제합니다.
        }
    }

    void StartQuestion()
    {
        if (questionPanel != null && isNearDesk)
        {
            // 여기서 질문을 설정하고 패널을 활성화합니다.
            questionText.text = "정답은 무엇입니까?";
            questionPanel.SetActive(true);
            answerInputField.text = ""; // 입력 필드 초기화
            answerInputField.Select(); // 입력 필드 선택
            isAnsweringQuestion = true; // 질문에 답변 중임을 설정합니다.
            if (resultText != null)
            {
                resultText.gameObject.SetActive(false); // 질문 시작 시 결과 텍스트를 숨깁니다.
            }
        }
    }

    void CheckAnswer()
    {
        if (answerInputField != null && resultText != null)
        {
            string userAnswer = answerInputField.text.Trim().ToLower(); // 사용자 입력을 소문자로 변환하여 공백 제거
            if (userAnswer == "마약류관리법")
            {
                resultText.text = "정답입니다!";
                resultText.color = Color.red;
                resultText.gameObject.SetActive(true);
                Debug.Log("정답입니다!"); // 디버그 메시지 추가
                StartCoroutine(HideQuestionPanelAfterDelay(resultDisplayTime));
            }
            else
            {
                resultText.text = "다시 생각해봅시다.";
                resultText.color = Color.red;
                resultText.gameObject.SetActive(true);
                Debug.Log("다시 생각해봅시다."); // 디버그 메시지 추가
                StartCoroutine(HideQuestionPanelAfterDelay(resultDisplayTime));
            }
        }
        else
        {
            Debug.LogError("answerInputField 또는 resultText가 null입니다."); // 디버그 메시지 추가
        }
    }

    IEnumerator HideQuestionPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (questionPanel != null)
        {
            questionPanel.SetActive(false); // 질문 패널 숨기기
        }
        if (resultText != null)
        {
            resultText.gameObject.SetActive(false); // 결과 텍스트 숨기기
        }
        isAnsweringQuestion = false; // 답변 중 상태 해제
    }
}
