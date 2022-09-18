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

    // Update is called once per frame
    void Update()
    {
        
    }
}
