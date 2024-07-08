using UnityEngine;
using TMPro; // TextMesh Pro 사용을 위해 필요
using System.Collections.Generic;

public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 Instance { get; private set; }

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    private Queue<string> dialogueLines;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 변경 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스 파괴
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

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
