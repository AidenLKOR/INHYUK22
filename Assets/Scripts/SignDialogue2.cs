using UnityEngine;

public class SignDialogue2 : MonoBehaviour
{
    public string[] dialogueLines;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager2.Instance.StartDialogue(dialogueLines);
        }
    }
}
