using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager1 : MonoBehaviour
{
    public static DialogueManager1 Instance;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string[] dialogueLines;
    private int currentLine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLine = 0;
        dialogueBox.SetActive(true);
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueLines = null;
    }
}
