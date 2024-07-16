using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f;
    private GameObject currentNPC;
    private GameObject currentInteractableObject;
    private bool isInteracting = false;

    void Update()
    {
        if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            if (isInteracting)
            {
                ContinueNPCDialogue();
            }
            else
            {
                StartNPCDialogue();
            }
        }
        else if (currentInteractableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            InteractableObject interactable = currentInteractableObject.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                if (isInteracting)
                {
                    interactable.HideMessage();
                    isInteracting = false;
                }
                else
                {
                    interactable.ShowMessage();
                    isInteracting = true;

                    // 미니 게임 시작
                    interactable.TriggerMiniGame();
                }
            }
        }
    }

    private void StartNPCDialogue()
    {
        NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
        if (npcDialogue != null)
        {
            npcDialogue.StartDialogue();
            isInteracting = true;
        }
    }

    private void ContinueNPCDialogue()
    {
        NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
        if (npcDialogue != null)
        {
            npcDialogue.ShowNextLine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            currentNPC = collision.gameObject;
        }
        else if (collision.CompareTag("Interactable"))
        {
            currentInteractableObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (currentNPC == collision.gameObject)
            {
                currentNPC = null;
                isInteracting = false;
            }
        }
        else if (collision.CompareTag("Interactable"))
        {
            if (currentInteractableObject == collision.gameObject)
            {
                currentInteractableObject = null;
                if (isInteracting)
                {
                    InteractableObject interactable = collision.GetComponent<InteractableObject>();
                    if (interactable != null)
                    {
                        interactable.HideMessage();
                    }
                    isInteracting = false;
                }
            }
        }
    }
}
