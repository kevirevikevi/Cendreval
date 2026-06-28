using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Déplacement")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Détection du sol")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private float moveInput;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Déplacement horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Vérifier si au sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip du sprite
        if (moveInput > 0 && !facingRight) Flip();
        if (moveInput < 0 && facingRight) Flip();

        // Animations
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}