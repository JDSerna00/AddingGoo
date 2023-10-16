using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float climbSpeed = 5f;
    public float wallSlideSpeed = 1f;
    public float wallJumpForceX = 5f;
    public float wallJumpForceY = 5f;
    public Transform groundCheck;
    public Transform wallCheck;
    public float groundCheckRadius = 0.2f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isWallSliding;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isWallSliding = Physics2D.Raycast(wallCheck.position, transform.right * (isFacingRight ? 1 : -1), wallCheckDistance, whatIsGround);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isWallSliding && Input.GetButtonDown("Jump"))
        {
            WallJump();
        }

        float moveInput = Input.GetAxis("Horizontal");
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (isWallSliding)
        {
            if (Input.GetButtonDown("Jump"))
            {
                WallJump();
            }
            else if (Input.GetAxis("Vertical") != 0)
            {
                ClimbWall();
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void WallJump()
    {
        rb.AddForce(new Vector2(-transform.right.x * wallJumpForceX, wallJumpForceY));
    }

    private void ClimbWall()
    {
        rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * climbSpeed);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
