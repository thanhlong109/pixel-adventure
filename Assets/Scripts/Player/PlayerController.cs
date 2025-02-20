using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private int maxJump = 2;
    [SerializeField] private int jumpLeft = 2;

    [Header("Check Grounded")]
    [SerializeField] private Transform leftCheck;
    [SerializeField] private Transform rightCheck;
    [SerializeField] private float raycastLength = 0.1f;
    [SerializeField] private LayerMask groudLayer;
    [SerializeField] private bool grounded = true;

    private Rigidbody2D rb;
    private int currentDireaction = 1; // 1 = right -1 = left 
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        UpdateAnimations();
        CheckStatus();
    }

    private void UpdateAnimations()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("YSpeed", rb.velocity.y);
        animator.SetBool("IsGrounded", grounded);
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        rb.velocity = new Vector2(GameInputManager.Instance.MoveDirection * speed, rb.velocity.y);
        FlipCharater();
    }

    private void FlipCharater()
    {
        if(currentDireaction * GameInputManager.Instance.MoveDirection < 0)
        {
            var scale = transform.localScale;
            scale.x *= -1;
            currentDireaction *= -1;
            transform.localScale = scale;
        }
    }

    private void Jump()
    {
        if (GameInputManager.Instance.JumpPressed && jumpLeft >= 1)
        {
            rb.velocity = new Vector2(GameInputManager.Instance.MoveDirection * speed, jumpForce);
            jumpLeft--;
            GameInputManager.Instance.JumpPressed = false;
        }
    }

    private void CheckStatus()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftCheck.position, Vector2.down, raycastLength, groudLayer);
        SeeRaycast(leftHit, leftCheck);

        RaycastHit2D rightHit = Physics2D.Raycast(rightCheck.position, Vector2.down, raycastLength, groudLayer);
        SeeRaycast(rightHit, rightCheck);

        grounded = leftHit || rightHit;
        if (grounded) jumpLeft = maxJump;
    }

    // for see raycast in screen
    private void SeeRaycast(RaycastHit2D hit, Transform checkPoint)
    {
        Color color = hit ? Color.green : Color.red;
        Debug.DrawRay(checkPoint.position, Vector2.down * raycastLength, color);
    }
}
