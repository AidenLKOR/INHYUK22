using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshProUGUI 사용을 위해 추가

public class SelfDialogueManager : MonoBehaviour
{
    public GameObject selfDialogueBox;
    public TextMeshProUGUI selfDialogueText; // Text 대신 TextMeshProUGUI 사용
    public string[] dialogueLines;
    private int currentLineIndex = 0;
    public float dialogueDelay = 0.1f;
    private Coroutine currentTypingCoroutine; // 현재 타이핑 코루틴을 추적하는 변수

    void Start()
    {
        if (selfDialogueBox == null)
        {
            Debug.LogError("Dialogue box not assigned.");
            return;
        }

        if (selfDialogueText == null)
        {
            Debug.LogError("Dialogue text not assigned.");
            return;
        }

        selfDialogueBox.SetActive(true);
        ShowNextLine(); // 첫 번째 대사를 표시합니다.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    IEnumerator DisplayLine()
    {
        selfDialogueText.text = string.Empty;
        foreach (char letter in dialogueLines[currentLineIndex].ToCharArray())
        {
            selfDialogueText.text += letter;
            yield return new WaitForSeconds(dialogueDelay);
        }
    }

    void ShowNextLine()
    {
        if (currentTypingCoroutine != null)
        {
            StopCoroutine(currentTypingCoroutine); // 현재 진행 중인 타이핑 코루틴을 중지합니다.
        }

        if (currentLineIndex < dialogueLines.Length)
        {
            currentTypingCoroutine = StartCoroutine(DisplayLine());
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        if (currentTypingCoroutine != null)
        {
            StopCoroutine(currentTypingCoroutine); // 대화가 끝날 때 현재 타이핑 코루틴을 중지합니다.
        }

        selfDialogueBox.SetActive(false);
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.0f); // Optional delay before scene change
        SceneManager.LoadScene("#6.policehouse");
    }
}
