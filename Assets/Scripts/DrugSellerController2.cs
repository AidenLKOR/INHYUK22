using UnityEngine;

public class DrugSellerController2 : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform player;
    public float stopDistance = 1.5f;
    public string[] dialogueLines;

    private bool isChasing = false;
    private bool isDialogActive = false; // 대화 진행 중인지 여부

    void Update()
    {
        if (isChasing && !isDialogActive)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > stopDistance)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                // 대화를 시작하고 대화 상태를 활성화합니다.
                if (DialogueManager2.Instance != null)
                {
                    DialogueManager2.Instance.StartDialogue(dialogueLines);
                    isDialogActive = true;
                }
            }
        }

        // E 키 입력을 받아 다음 대화로 넘기기
        if (isDialogActive && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueManager2.Instance != null)
            {
                DialogueManager2.Instance.DisplayNextLine();
                // 대화가 끝났는지 확인 후 처리
                if (!DialogueManager2.Instance.IsDialogueActive())
                {
                    isDialogActive = false;
                    DialogueManager2.Instance.EndDialogue(); // 대화가 끝났을 때 대화창을 닫습니다.
                    EndChase(); // 캐릭터를 화면에서 사라지게 합니다.
                }
            }
        }
    }

    public void StartChase()
    {
        isChasing = true;
    }

    private void EndChase()
    {
        // 캐릭터를 화면에서 사라지게 하는 처리를 여기에 구현합니다.
        gameObject.SetActive(false); // 예시로 캐릭터를 비활성화 처리하는 코드입니다.
    }
}
