using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed, jumpForce;

    private bool moveLeft, moveRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
        jumpForce = 500f;
        moveLeft = false;
        moveRight = false;  
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
    }
}
