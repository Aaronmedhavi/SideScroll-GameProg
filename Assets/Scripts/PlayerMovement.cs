using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isWalking = false;
    private bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    #region AnimationHandler
    private void UpdateAnimationState(bool walking)
    {
        if (walking && !isWalking)
        {
            animator.SetBool("isWalking", true);
            isWalking = true;
        }
        else if (!walking && isWalking)
        {
            animator.SetBool("isWalking", false);
            isWalking = false;
        }
    }

    private void PlayJump()
    {
        animator.SetTrigger("goJump");
        AudioManager.Instance.PlayJumpSound();
    }

    private void PlayAttack()
    {
        if (!isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        animator.SetTrigger("goAttack");
        AudioManager.Instance.PlayAttackSound();
        // Wait for the attack animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false;
    }
    #endregion

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        // Only allow movement if not attacking
        if (!isAttacking)
        {
            transform.Translate(new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f));
            SpriteFlip(horizontalInput);
            UpdateAnimationState(Mathf.Abs(horizontalInput) > 0.01f);
        }

        // Restored original jump logic
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            PlayJump();
        }

        // Check for left mouse click to trigger attack
        if (Input.GetMouseButtonDown(0))
        {
            PlayAttack();
        }
    }
}