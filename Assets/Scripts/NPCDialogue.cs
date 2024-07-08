using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueLine[] dialogueLines; // 대사 내용
    private int currentLine = 0;
    private bool isDialogueActive = false;

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    public void StartDialogue()
    {
        if (dialogueLines.Length > 0 && DialogueManager.Instance != null)
        {
            currentLine = 0;
            DialogueManager.Instance.StartDialogue(dialogueLines);
            isDialogueActive = true;
        }
        else
        {
            Debug.LogWarning("Dialogue lines are empty or DialogueManager instance is null!");
        }
    }

    public void ShowNextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            DialogueManager.Instance.DisplayNextLine();
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
    }
}
