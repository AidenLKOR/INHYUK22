using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // �߷� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ȸ�� ����
    }

    void Update()
    {
        // �̵� �Է� �� ��������
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �밢�� �̵� ����
        if (moveHorizontal != 0)
        {
            moveVertical = 0;
        }

        moveInput = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        // �̵� ��ġ ����
        Vector2 targetPosition = rb.position + moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    // AnimationEvent���� ȣ���� �Լ�
    public void OnAnimationEvent()
    {
        Debug.Log("�ִϸ��̼� �̺�Ʈ ȣ���");
    }
}
