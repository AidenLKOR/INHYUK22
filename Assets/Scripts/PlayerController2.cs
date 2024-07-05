using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canMove = true; // ������ �� �ִ��� ���θ� ��Ÿ���� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // �߷� ����
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // ȸ�� ����
    }

    void Update()
    {
        if (canMove)
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
        else
        {
            moveInput = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetPosition = rb.position + moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    public void StopMoving()
    {
        canMove = false;
    }

    public void StartMoving()
    {
        canMove = true;
    }
}
