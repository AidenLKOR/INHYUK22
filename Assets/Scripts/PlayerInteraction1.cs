using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2.0f; // 상호작용 거리
    private GameObject currentNPC; // 현재 상호작용 중인 NPC
    private bool isInteracting = false; // 대화 중 여부

    void Update()
    {
        if (currentNPC != null && !isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            StartNPCDialogue(); // NPC와의 대화를 시작합니다.
        }
        else if (isInteracting && Input.GetKeyDown(KeyCode.E))
        {
            ContinueNPCDialogue(); // NPC와의 대화를 진행합니다.
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
        else
        {
            Debug.LogWarning("NPCDialogue component is null!");
        }
    }

    private void ContinueNPCDialogue()
    {
        NPCDialogue npcDialogue = currentNPC.GetComponent<NPCDialogue>();
        if (npcDialogue != null && isInteracting)
        {
            Debug.Log("Continuing NPC dialogue..."); // 디버그 로그 추가
            npcDialogue.ShowNextLine(); // 다음 대사를 표시합니다.
        }
        else
        {
            Debug.LogWarning("NPCDialogue component is null or not interacting!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC") || collision.CompareTag("Sign"))
        {
            Debug.Log("Interactable entered..."); // 디버그 로그 추가
            currentNPC = collision.gameObject; // 현재 상호작용 중인 NPC를 설정합니다.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC") || collision.CompareTag("Sign"))
        {
            if (currentNPC == collision.gameObject)
            {
                Debug.Log("Interactable exited..."); // 디버그 로그 추가
                currentNPC = null; // NPC와의 상호작용이 끝나면 초기화합니다.
                isInteracting = false; // 대화 중 상태를 해제합니다.
            }
        }
    }
}
