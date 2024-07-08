using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField] private float walkSpeed = 8f;
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float jumpPower = 16f;
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = true;
    private bool isDashing = false;
    private float dashDirection;
    private float dashStartTime;
    private float lastDashTime = -Mathf.Infinity;
    public Animator animator;

    void Update()
    {
        if (!isDashing)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                animator.SetFloat("speed", math.abs(horizontal) * 1.5f); 
            }
            else
            {
                animator.SetFloat("speed", math.abs(horizontal));
            }

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                isGrounded = false;
                animator.SetBool("isJumping", true);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && Time.time >= lastDashTime + dashCooldown)
            {
                StartDash();
            }
            
            Flip();
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);

            if (Time.time >= dashStartTime + dashTime)
            {
                EndDash();
                animator.SetTrigger("isDash");
            }
        }
        else
        {
            float currentSpeed = walkSpeed;

            
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                currentSpeed = runSpeed;
            }

            rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);
        }
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void StartDash()
    {
        isDashing = true;
        dashDirection = isFacingRight ? 1 : -1;
        dashStartTime = Time.time;
        lastDashTime = Time.time;
        animator.SetTrigger("isDash");
    }

    private void EndDash()
    {
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            OnLanding();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (rb.transform.localScale == new Vector3((float)-0.4751819, (float)0.4751819, (float)0.158394))
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
