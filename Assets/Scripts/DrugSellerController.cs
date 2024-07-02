using UnityEngine;

public class DrugSellerController : MonoBehaviour
{
    public Transform player; // 주인공 캐릭터
    public float speed = 3f; // 이동 속도
    public float stopDistance = 1f; // 멈추는 거리
    private bool isChasing = false; // 추적 여부
    private PlayerController playerController; // 주인공 캐릭터의 컨트롤러
    [SerializeField] private DialogueManager dialogueManager; // 대화 매니저
    public string[] dialogueLines; // 대화 내용

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager is not set in the inspector");
        }
    }

    void Update()
    {
        if (isChasing)
        {
            // 주인공 캐릭터와의 거리 계산
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                // 주인공 캐릭터를 향해 이동
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // 멈추기
                Debug.Log("DrugSeller reached the player and stopped.");
                isChasing = false;
                playerController.StopMoving(); // 주인공 멈추기
                StartDialogue(); // 대화 시작
            }
        }
    }

    public void StartChase()
    {
        Debug.Log("StartChase called...");
        isChasing = true;
        playerController.StopMoving(); // 주인공 멈추기
    }

    private void StartDialogue()
    {
        if (dialogueManager != null)
        {
            // 대화 시작
            Debug.Log("Starting dialogue with the player...");
            dialogueManager.StartDialogue(dialogueLines);
        }
        else
        {
            Debug.LogError("DialogueManager is not set.");
        }
    }
}
