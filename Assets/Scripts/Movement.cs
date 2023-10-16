using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float wallSlideSpeed = 0.5f;
    public float wallJumpForce = 5.0f;
    public LayerMask wallLayer;
    private float moveDirection = 0;
    private bool isWallSliding = false;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = IsGrounded();

        moveDirection = Input.GetAxis("Horizontal");

        isWallSliding = CheckWallSlide();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (!isWallSliding)
        {
            Vector2 moveVelocity = rb.velocity;
            moveVelocity.x = moveDirection * moveSpeed;
            rb.velocity = moveVelocity;
        }
        else
        {
            Vector2 wallSlideVelocity = rb.velocity;
            wallSlideVelocity.y = -wallSlideSpeed;
            rb.velocity = wallSlideVelocity;
        }

        if (isGrounded)
        {
            rb.gravityScale = 1.0f;
        }
        else
        {
            rb.gravityScale = 0.0f;
        }
    }

    private bool IsGrounded()
    {
        float checkDistance = 0.05f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, wallLayer);
        return hit.collider != null;
    }

    private void Jump()
    {
        if (isWallSliding)
        {
            // Salto de la pared
            Vector2 jumpForce = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForce, wallJumpForce);
            rb.velocity = jumpForce;
        }
        else if (isGrounded)
        {
            // Salto normal
            Vector2 jumpForce = new Vector2(0, wallJumpForce);
            rb.velocity = jumpForce;
        }
    }

    private bool CheckWallSlide()
    {
        float castDistance = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, castDistance, wallLayer);

        if (hit.collider != null && !hit.collider.CompareTag("Ground"))
        {
            return true;
        }

        return false;
    }
}
