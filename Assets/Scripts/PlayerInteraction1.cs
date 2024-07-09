using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f; // 상호작용 거리
    private GameObject currentNPC; // 현재 상호작용 중인 NPC
    private GameObject currentInteractableObject; // 현재 상호작용 중인 오브젝트
    private bool isInteracting = false; // 대화 중 여부

    void Update()
    {
        if (currentNPC != null && Input.GetKeyDown(KeyCode.E))
        {
            if (isInteracting)
            {
                ContinueNPCDialogue(); // NPC와의 대화를 진행합니다.
            }
            else
            {
                StartNPCDialogue(); // NPC와의 대화를 시작합니다.
            }
        }
        else if (currentInteractableObject != null && Input.GetKeyDown(KeyCode.E))
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
                    isInteracting = true; // 상호작용 상태를 활성화합니다.
                }
            }
        }
    }

    private void StartNPCDialogue()
    {
        NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
        if (npcDialogue != null)
        {
            Debug.Log("Starting NPC dialogue..."); // 디버그 로그 추가
            npcDialogue.StartDialogue(); // NPC와의 대화를 시작합니다.
            isInteracting = true; // 대화 중 상태로 설정합니다.
        }
    }

    private void ContinueNPCDialogue()
    {
        NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
        if (npcDialogue != null)
        {
            Debug.Log("Continuing NPC dialogue..."); // 디버그 로그 추가
            npcDialogue.ShowNextLine(); // 다음 대사를 표시합니다.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            Debug.Log("NPC entered..."); // 디버그 로그 추가
            currentNPC = collision.gameObject; // 현재 상호작용 중인 NPC를 설정합니다.
        }
        else if (collision.CompareTag("Interactable"))
        {
            Debug.Log("Interactable object entered..."); // 디버그 로그 추가
            currentInteractableObject = collision.gameObject; // 현재 상호작용 중인 오브젝트를 설정합니다.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            if (currentNPC == collision.gameObject)
            {
                Debug.Log("NPC exited..."); // 디버그 로그 추가
                currentNPC = null; // NPC와의 상호작용이 끝나면 초기화합니다.
                isInteracting = false; // 대화 중 상태를 해제합니다.
            }
        }
        else if (collision.CompareTag("Interactable"))
        {
            if (currentInteractableObject == collision.gameObject)
            {
                Debug.Log("Interactable object exited..."); // 디버그 로그 추가
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
    }
}
