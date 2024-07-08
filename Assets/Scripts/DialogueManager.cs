using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text speakerText;
    public Image speakerImage;
    public Sprite npcSprite;
    public Sprite playerSprite;

    private Queue<DialogueLine> dialogueLines;

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
        dialogueLines = new Queue<DialogueLine>();
        dialogueBox.SetActive(false); // 초기에는 대화창을 숨깁니다.
    }

    public void StartDialogue(DialogueLine[] lines)
    {
        dialogueLines.Clear();
        foreach (DialogueLine line in lines)
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

        DialogueLine line = dialogueLines.Dequeue();
        dialogueText.text = line.line;
        speakerText.text = line.speaker;

        if (line.speaker == "NPC")
        {
            speakerImage.sprite = npcSprite;
        }
        else if (line.speaker == "Player")
        {
            speakerImage.sprite = playerSprite;
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }
}
