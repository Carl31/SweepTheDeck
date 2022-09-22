using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed, jumpForce;

    private bool moveLeft, moveRight;

    public Animator animator;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 8f;
        jumpForce = 15f;
        moveLeft = false;
        moveRight = false;
        animator = GetComponent<Animator>();
    }

    public void MoveLeft()
    {
        moveLeft = true;
        animator.SetFloat("Speed", 1);
        gameObject.transform.localScale = new Vector3(-2, 2, 2);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void MoveRight()
    {
        moveRight = true;
        animator.SetFloat("Speed", 1);
        gameObject.transform.localScale = new Vector3(2, 2, 2);
    }

    public void Jump()
    {
        animator.SetBool("IsJumping", true);
        if (rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
        animator.SetFloat("Speed", -1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
         
    }
}
