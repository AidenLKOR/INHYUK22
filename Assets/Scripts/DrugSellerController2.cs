using UnityEngine;

public class DrugSellerController2 : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform player;
    public float stopDistance = 1.5f;
    public string[] dialogueLines;

    private bool isChasing = false;
    private bool hasStopped = false;

    void Update()
    {
        if (isChasing && !hasStopped)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                hasStopped = true;
                if (DialogueManager2.Instance != null)
                {
                    DialogueManager2.Instance.StartDialogue(dialogueLines);
                }
            }
        }
    }

    public void StartChase()
    {
        isChasing = true;
    }
}
