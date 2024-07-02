using UnityEngine;

public class DrugSellerController : MonoBehaviour
{
    public Transform player; // ���ΰ� ĳ����
    public float speed = 3f; // �̵� �ӵ�
    public float stopDistance = 1f; // ���ߴ� �Ÿ�
    private bool isChasing = false; // ���� ����
    private PlayerController playerController; // ���ΰ� ĳ������ ��Ʈ�ѷ�
    [SerializeField] private DialogueManager dialogueManager; // ��ȭ �Ŵ���
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
        if (dialogueManager != null)
        {
            // ��ȭ ����
            Debug.Log("Starting dialogue with the player...");
            dialogueManager.StartDialogue(dialogueLines);
        }
        else
        {
            Debug.LogError("DialogueManager is not set.");
        }
    }
}
