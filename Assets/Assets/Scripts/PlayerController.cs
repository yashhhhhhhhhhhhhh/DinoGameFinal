using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D boxCollider;

    public float jumpForce = 7f;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        originalColliderSize = boxCollider.size;
        originalColliderOffset = boxCollider.offset;
    }

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
        {
            HandleJump();
            HandleCrouch();
        }
        else
        {
            animator.enabled = false;
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
            animator.SetTrigger("Jump");
        }
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);

            boxCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y / 2);
            boxCollider.offset = new Vector2(originalColliderOffset.x, originalColliderOffset.y - 0.25f);
        }
        else
        {
            animator.SetBool("isCrouching", false);
            boxCollider.size = originalColliderSize;
            boxCollider.offset = originalColliderOffset;
        }
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(rb.linearVelocity.y) < 0.01f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            ScoreManager.Instance.DecreaseLife();
        }
    }
}
