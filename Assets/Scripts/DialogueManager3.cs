using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager3 : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private Queue<string> sentences;

    void Awake()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (dialogueBox.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void ShowDialogue(string[] lines)
    {
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
