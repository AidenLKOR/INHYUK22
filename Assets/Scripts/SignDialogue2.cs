using UnityEngine;

public class SignDialogue2 : MonoBehaviour
{
    public string[] dialogueLines;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueManager2.Instance != null)
            {
                Debug.Log("DialogueManager2 instance found.");
                if (DialogueManager2.Instance.IsDialogueActive())
                {
                    Debug.Log("Ending dialogue...");
                    DialogueManager2.Instance.EndDialogue();
                }
                else
                {
                    Debug.Log("Starting dialogue...");
                    DialogueManager2.Instance.StartDialogue(dialogueLines);
                }
            }
            else
            {
                Debug.LogWarning("DialogueManager2 instance is null.");
            }
        }
    }
}
