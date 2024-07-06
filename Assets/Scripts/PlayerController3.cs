using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal != 0)
            {
                moveVertical = 0;
            }

            moveInput = new Vector2(moveHorizontal, moveVertical).normalized;

            if (Input.GetKeyDown(KeyCode.E))
            {
                SignDialogue3 signDialogue = FindObjectOfType<SignDialogue3>();
                if (signDialogue != null && signDialogue.enabled)
                {
                    signDialogue.TriggerDialogue();
                }
            }
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
