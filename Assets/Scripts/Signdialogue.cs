using UnityEngine;

public class SignDialogue : MonoBehaviour
{
    public string[] dialogueLines;

    public void StartDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogueLines);
        }
        else
        {
            Debug.LogError("DialogueManager not found!");
        }
    }
}
