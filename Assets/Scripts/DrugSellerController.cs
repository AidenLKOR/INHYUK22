using UnityEngine;

public class DrugSellerController : MonoBehaviour
{
    public Transform player; // ���ΰ� ĳ����
    public float speed = 3f; // �̵� �ӵ�
    public float stopDistance = 1f; // ���ߴ� �Ÿ�
    public bool isChasing = false; // ���� ����
    public PlayerController playerController; // ���ΰ� ĳ������ ��Ʈ�ѷ�
    [SerializeField] public DialogueManager dialogueManager; // ��ȭ �Ŵ���
    public string[] dialogueLines; // ��ȭ ����

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
            // ���ΰ� ĳ���Ϳ��� �Ÿ� ���
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                // ���ΰ� ĳ���͸� ���� �̵�
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // ���߱�
                Debug.Log("DrugSeller reached the player and stopped.");
                isChasing = false;
                playerController.StopMoving(); // ���ΰ� ���߱�
                StartDialogue(); // ��ȭ ����
            }
        }
    }

    public void StartChase()
    {
        Debug.Log("StartChase called...");
        isChasing = true;
        playerController.StopMoving(); // ���ΰ� ���߱�
    }

    private void StartDialogue()
    {
        Debug.Log("Starting dialogue with the player...");
        
        // 예시로 사용할 대사들
        string[] lines = new string[]
        {
            "이곳에 처음 왔구나?",
            "반갑다. 여기는 정말 멋진 곳이야.",
            "여기서 많은 것을 배울 수 있을 거야."
        };

        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(lines);
        }
        else
        {
            Debug.LogError("DialogueManager is null");
        }
    }
}