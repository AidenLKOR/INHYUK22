using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // 중력 무시
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 회전 고정
    }

    void Update()
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

    void FixedUpdate()
    {
        // 이동 위치 설정
        Vector2 targetPosition = rb.position + moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);
    }

    // AnimationEvent에서 호출할 함수
    public void OnAnimationEvent()
    {
        Debug.Log("애니메이션 이벤트 호출됨");
    }
}
