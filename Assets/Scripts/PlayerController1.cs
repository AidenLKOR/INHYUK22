using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canMove = true; // 움직일 수 있는지 여부를 나타내는 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 중력 무시
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 회전 고정
    }

    void Update()
    {
        if (canMove)
        {
            // 이동 입력 값 가져오기
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // 대각선 이동 방지
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
