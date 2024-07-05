using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 Instance { get; private set; }
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private Queue<string> sentences;

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

        if (dialogueBox == null || dialogueText == null)
        {
            Debug.LogError("DialogueBox or DialogueText not assigned.");
        }
        sentences = new Queue<string>();
    }

    public void StartDialogue(string[] lines)
    {
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
        dialogueBox.SetActive(true);
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}
