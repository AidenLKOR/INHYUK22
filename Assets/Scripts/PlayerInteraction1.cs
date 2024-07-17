using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f; // 상호작용 거리
    private GameObject currentInteractableObject; // 현재 상호작용 중인 오브젝트
    private GameObject currentNPC; // 현재 상호작용 중인 NPC
    private bool isInteracting = false; // 상호작용 중 여부

    void Update()
    {
        if (currentInteractableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            InteractableObject interactable = currentInteractableObject.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                if (isInteracting)
                {
                    interactable.HideMessage(); // 메시지를 숨깁니다.
                    isInteracting = false; // 상호작용 상태를 해제합니다.
                }
                else
                {
                    interactable.ShowMessage(); // 메시지를 표시합니다.
                    interactable.TriggerMiniGame(); // 미니게임을 트리거합니다.
                    isInteracting = true; // 상호작용 상태를 활성화합니다.
                }
            }
        }
        else if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
            if (npcDialogue != null)
            {
                if (isInteracting)
                {
                    npcDialogue.ShowNextLine(); // 다음 대사를 표시합니다.
                }
                else
                {
                    npcDialogue.StartDialogue(); // 대화를 시작합니다.
                    isInteracting = true; // 상호작용 상태를 활성화합니다.
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            currentInteractableObject = collision.gameObject; // 현재 상호작용 중인 오브젝트를 설정합니다.
        }
        else if (collision.CompareTag("NPC"))
        {
            currentNPC = collision.gameObject; // 현재 상호작용 중인 NPC를 설정합니다.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            if (currentInteractableObject == collision.gameObject)
            {
                currentInteractableObject = null; // 오브젝트와의 상호작용이 끝나면 초기화합니다.
                if (isInteracting)
                {
                    InteractableObject interactable = collision.GetComponent<InteractableObject>();
                    if (interactable != null)
                    {
                        interactable.HideMessage(); // 메시지를 숨깁니다.
                    }
                    isInteracting = false; // 상호작용 상태를 해제합니다.
                }
            }
        }
        else if (collision.CompareTag("NPC"))
        {
            if (currentNPC == collision.gameObject)
            {
                currentNPC = null; // NPC와의 상호작용이 끝나면 초기화합니다.
                if (isInteracting)
                {
                    NPCDialogue npcDialogue = collision.GetComponent<NPCDialogue>();
                    if (npcDialogue != null)
                    {
                        npcDialogue.EndDialogue(); // 대화를 종료합니다.
                    }
                    isInteracting = false; // 상호작용 상태를 해제합니다.
                }
            }
        }
    }
}
