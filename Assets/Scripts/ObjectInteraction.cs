using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject questionPanel; // 질문을 표시할 패널
    public TextMeshProUGUI questionText; // 질문 텍스트
    public TMP_InputField answerInputField; // 대답을 입력받을 인풋 필드
    public TextMeshProUGUI resultText; // 정답 및 오답 결과 텍스트
    public float interactionRadius = 2.0f; // 상호작용 반경
    public float resultDisplayTime = 2.0f; // 결과를 표시할 시간
    public GameObject rock1; // Rock1 오브젝트
    public GameObject rock2; // Rock2 오브젝트

    private bool isAnsweringQuestion = false; // 질문에 답변 중인지 여부
    private Collider2D currentInteractionObject = null; // 현재 상호작용 중인 오브젝트
    private HashSet<string> answeredTags = new HashSet<string>(); // 정답을 맞춘 NPC 태그 집합

    // 질문과 정답을 저장할 Dictionary
    private Dictionary<string, (string question, string answer)> questionAnswerDict = new Dictionary<string, (string, string)>()
    {
        { "Desk", ("정답은 무엇일까요? (6글자)", "마약류관리법") },
        { "NPC_red", ("인체의 중추신경을 자극하여 과도한 흥분, 억제 효과를 가져오는 유해한 약물을 무엇이라고 할까요?", "마약") },
        { "NPC_orange", ("약물을 계속 사용하면서 스스로 중단할 수 없는 상태를 무엇이라고 할까요?", "약물중독") },
        { "NPC_yellow", ("약물을 중단했을 때, 삶의 의욕이 없어지고, 경련, 불안을 느끼는 증상을 무엇이라고 할까요?", "금단증상") },
        { "NPC_green", ("모르는 사람이 주는 음식은 함부로 먹어도 될까요? (네/아니오)", "아니오") },
        { "NPC_blue", ("마약은 마약을 사용하는 본인에게만 피해를 줄까요? (네/아니오)", "아니오") },
        { "NPC_navy", ("마약범죄 신고 번호는 무엇일까요?", "112") },
        { "NPC_purple", ("24시간 마약중독 상담센터 번호는 무엇일까요?", "1342") }
    };

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
        if (rock1 != null)
        {
            rock1.SetActive(true); // Rock1 초기 활성화 상태 설정
        }
        if (rock2 != null)
        {
            rock2.SetActive(true); // Rock2 초기 활성화 상태 설정
        }
    }

    void Update()
    {
        // 현재 상호작용 오브젝트가 있고, Q 키를 눌렀을 때만 질문 시작
        if (currentInteractionObject != null && Input.GetKeyDown(KeyCode.Q))
        {
            StartQuestion(); // Q 키를 눌렀을 때 질문을 시작합니다.
        }

        if (isAnsweringQuestion && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer(); // Enter 키를 눌렀을 때 정답을 확인합니다.
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (questionAnswerDict.ContainsKey(other.tag))
        {
            Debug.Log($"Interacting with {other.tag}. Press Q to answer the question.");
            currentInteractionObject = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (questionAnswerDict.ContainsKey(other.tag))
        {
            Debug.Log($"Stopped interacting with {other.tag}.");
            if (currentInteractionObject == other)
            {
                currentInteractionObject = null;
            }
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
        if (questionPanel != null && currentInteractionObject != null)
        {
            // 현재 태그에 해당하는 질문을 설정하고 패널을 활성화합니다.
            questionText.text = questionAnswerDict[currentInteractionObject.tag].question;
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
        if (answerInputField != null && resultText != null && currentInteractionObject != null)
        {
            string userAnswer = answerInputField.text.Trim().ToLower(); // 사용자 입력을 소문자로 변환하여 공백 제거
            if (userAnswer == questionAnswerDict[currentInteractionObject.tag].answer.ToLower())
            {
                resultText.text = "정답입니다!";
                resultText.color = Color.red;
                resultText.gameObject.SetActive(true);
                Debug.Log("정답입니다!"); // 디버그 메시지 추가

                if (currentInteractionObject.tag != "Desk")
                {
                    answeredTags.Add(currentInteractionObject.tag); // 정답을 맞춘 NPC 태그 추가
                    Destroy(currentInteractionObject.gameObject); // 해당 NPC 오브젝트 제거
                    CheckAllNPCsAnswered(); // 모든 NPC 정답 확인
                }

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

    void CheckAllNPCsAnswered()
    {
        bool allAnswered = true;
        foreach (var key in questionAnswerDict.Keys)
        {
            if (key != "Desk" && !answeredTags.Contains(key))
            {
                allAnswered = false;
                break;
            }
        }

        if (allAnswered)
        {
            if (rock1 != null)
            {
                rock1.SetActive(false); // Rock1 오브젝트 비활성화
            }
            if (rock2 != null)
            {
                rock2.SetActive(false); // Rock2 오브젝트 비활성화
            }
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
