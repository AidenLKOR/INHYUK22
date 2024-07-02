using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private Queue<string> dialogueLines;

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

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
