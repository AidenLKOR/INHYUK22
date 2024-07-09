using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox; // 대화창 패널
    public TextMeshProUGUI dialogueText; // 대화 텍스트
    public string[] dialogueLines; // 대사 내용
    private int currentLine = 0; // 현재 대사 라인
    private bool isDialogueActive = false; // 대화 활성화 여부

    void Start()
    {
        dialogueBox.SetActive(false); // 초기에는 대화창을 숨깁니다.
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine(); // 대화창이 활성화되어 있을 때 E 키를 누르면 다음 대사를 보여줍니다.
        }
    }

    public void StartDialogue()
    {
        if (dialogueLines.Length > 0)
        {
            Debug.Log("Starting dialogue..."); // 디버그 로그 추가
            dialogueBox.SetActive(true); // 대화창을 활성화합니다.
            currentLine = 0;
            ShowLine(currentLine); // 첫 번째 대사를 표시합니다.
            isDialogueActive = true; // 대화를 활성화합니다.
        }
        else
        {
            Debug.LogWarning("Dialogue lines are empty!"); // 대사 내용이 없는 경우 경고를 출력합니다.
        }
    }

    public void ShowNextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            ShowLine(currentLine); // 다음 대사를 표시합니다.
        }
        else
        {
            EndDialogue(); // 대화가 끝나면 대화창을 숨깁니다.
        }
    }

    public void ShowLine(int lineIndex)
    {
        if (lineIndex >= 0 && lineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[lineIndex];
            Debug.Log("Displaying line: " + dialogueLines[lineIndex]); // 디버그 로그 추가
        }
        else
        {
            Debug.LogWarning("Line index out of range: " + lineIndex); // 인덱스가 범위를 벗어난 경우 경고를 출력합니다.
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Ending dialogue..."); // 디버그 로그 추가
        dialogueBox.SetActive(false); // 대화창을 숨깁니다.
        isDialogueActive = false; // 대화를 비활성화합니다.
    }
}
