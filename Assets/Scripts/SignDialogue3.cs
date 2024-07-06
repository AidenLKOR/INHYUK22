using UnityEngine;

public class SignDialogue3 : MonoBehaviour
{
    public string[] dialogueLines;
    private bool playerInRange;
    private DialogueManager3 dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager3>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        if (!dialogueManager.dialogueBox.activeInHierarchy)
        {
            dialogueManager.ShowDialogue(dialogueLines);
        }
        else
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
