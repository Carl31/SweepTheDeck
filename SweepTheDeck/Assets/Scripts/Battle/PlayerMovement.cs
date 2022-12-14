using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public PlayFabManager playFabManager;
    public GameObject gameOverScreen;
    public TMP_Text gameScore;
    //public int score;

    private Rigidbody2D rb;

    public float moveSpeed, jumpForce;

    private bool moveLeft, moveRight;
    private bool isDead = false;

    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator animator;
    public int attackDamage = 40;

    public Transform firePoint;
    public Transform attackPoint;

    private bool isFacingRight = true;

    public HealthbarBehaviour Healthbar;
    public float currentHealth;
    public float MaxHealth = 100f;

    public GameObject bulletPrefab;

    private bool grounded;

    int nCoins; //nCoins collected in this game instance


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
        nCoins = PlayerPrefs.GetInt(PlayerItems.PLAYER_COINS, 0);
        gameOverScreen.SetActive(false);
    }

    public void MoveLeft()
    {
        moveLeft = true;
        animator.SetFloat("Speed", 1);
        if(isFacingRight == true)
        {
            Flip();
        }
        AudioManager.instance.PlayWalk();
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
        AudioManager.instance.PlayWalk();
        // gameObject.transform.localScale = new Vector3(180, 180, 180);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Behaviour>().takeDamage(attackDamage);
            //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        AudioManager.instance.PlayAttack();
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth, MaxHealth);

        if (currentHealth <= 0)
        {
            die();
        }
        AudioManager.instance.PlayDamagePlayer();
    }

    public void Shoot()
    {
        animator.SetTrigger("Attack");
        //shooting stuff ;D
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioManager.instance.PlayGunshot();
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
        AudioManager.instance.PlayJump();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("IsJumping", false);
            AudioManager.instance.PlayWalk();
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            nCoins++;
            PlayerPrefs.SetInt(PlayerItems.PLAYER_COINS, nCoins);
            Debug.Log("Player nCoins: " + nCoins); // for debugging
            CoinCounter.instance.UpdateCount(1);
            AudioManager.instance.PlayCoin();
        }
    }
    void die()
    {
        if (!isDead)
        {
            animator.SetBool("IsDead", true);
            isDead = true;
            AudioManager.instance.PlayPlayerDie();
            GameOver();
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
    void GameOver()
    {
        int score = PlayerPrefs.GetInt(PlayerItems.PLAYER_SCORE, 0);
        Debug.Log(score);
        Debug.Log(nCoins);
        PlayerPrefs.SetInt(PlayerItems.PLAYER_COINS, nCoins);
        playFabManager.SendLeaderboard(score);
        Time.timeScale = 0;
        AudioListener.pause = true;
        gameScore.SetText("Score: " + score);
        gameOverScreen.SetActive(true);
        Debug.Log("game over");
    }
}
