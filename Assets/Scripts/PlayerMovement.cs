using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public float downwardForce = 0f;

    Animator animator;

    [SerializeField] private Rigidbody2D rb; //serialize field zorgt ervoor dat een private zoals een public kan gebruikt worden. k vindt t zelf extra hassle but sure lmfao
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //movement

        if (Input.GetButtonDown("Jump") && IsGrounded()) //als je jump drukt dan..
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //jump je
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //als je jump lang drukt
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); //dan blijf je langer in de air
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.S) && rb.velocity.y > 0.5f) //als je jump lang drukt
        {
            rb.velocity = Vector2.down * downwardForce; //dan val je naar beneden
        }
        Flip();

        if (IsGrounded() == false) {
            animator.SetBool("isJumping", false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //movement
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) //&& = and, || and/or? wasnt sure from tut (wat is !)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}