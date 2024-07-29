using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager4 : MonoBehaviour
{
    public static DialogueManager4 Instance { get; private set; }

    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    private Queue<string> dialogueLines;

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
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string line = dialogueLines.Dequeue();
        dialogueText.text = line;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueBox.activeSelf;
    }
}
