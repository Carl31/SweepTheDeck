using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed, jumpForce;

    private bool moveLeft, moveRight;
    private bool isDead = false;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator animator;
    public int attackDamage = 40;

    public Transform firePoint;
    public Transform attackPoint;

    private bool isFacingRight = true;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public HealthbarBehaviour Healthbar;
    public float currentHealth;
    public float MaxHealth = 100f;

    public GameObject bulletPrefab;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        Healthbar.SetHealth(currentHealth, MaxHealth);
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
<<<<<<< HEAD
        gameObject.transform.localScale = new Vector3(-180, 180, 180);
=======
        if(isFacingRight == true)
        {
            Flip();
        }
        //gameObject.transform.localScale = new Vector3(-180, 180, 180);
    }
    public void MoveRight()
    {
        moveRight = true;
        animator.SetFloat("Speed", 1);
        if(isFacingRight == false)
        {
            Flip();
        }
        // gameObject.transform.localScale = new Vector3(180, 180, 180);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
>>>>>>> CharacterDevelopment
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

<<<<<<< HEAD
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Behaviour>().takeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
=======
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Behaviour>().takeDamage(attackDamage);
        }
>>>>>>> CharacterDevelopment
    }

    public void takeDamage(float damage)
    {
<<<<<<< HEAD
        moveRight = true;
        animator.SetFloat("Speed", 1);
        gameObject.transform.localScale = new Vector3(180, 180, 180);
=======
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth, MaxHealth);

        if (currentHealth <= 0)
        {
            die();
        }
>>>>>>> CharacterDevelopment
    }

    public void Shoot()
    {
        animator.SetTrigger("Attack");
        //shooting stuff ;D
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
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
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
        }
    }
    void die()
    {
        if (!isDead)
        {
            animator.SetBool("IsDead", true);
            isDead = true;
            this.enabled = false;
            //Destroy(gameObject);
        }
        //Destroy(gameObject);
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
