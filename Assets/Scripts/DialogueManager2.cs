using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 Instance { get; private set; }

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public float dialogueDelay = 0.02f; // 대사 표시 딜레이 추가

    private Queue<string> dialogueLines;
    private Coroutine currentTypingCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 싱글톤 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        dialogueLines = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        dialogueLines.Clear();
        foreach (string line in lines)
        {
            dialogueLines.Enqueue(line);
        }

        dialogueBox.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (currentTypingCoroutine != null)
        {
            StopCoroutine(currentTypingCoroutine);
        }

        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueLines.Dequeue();
        currentTypingCoroutine = StartCoroutine(TypeLine(line)); // 대사 표시 코루틴 호출
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueDelay);
        }
    }

    public void EndDialogue()
    {
        if (currentTypingCoroutine != null)
        {
            StopCoroutine(currentTypingCoroutine);
        }

        dialogueBox.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueBox.activeSelf;
    }
}
