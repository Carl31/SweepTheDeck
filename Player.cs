using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public Animator anim;
    private bool grounded;

    private Rigidbody2D myBody;
    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0  ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;

        anim.SetFloat("Speed", Mathf.Abs(movement));
        

        if (Input.GetButtonDown("Jump") && grounded && Mathf.Abs(myBody.velocity.y) < 0.001f)
        {
            myBody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
            grounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
        anim.SetBool("IsJumping", false);
    }

    // carl testing
}
