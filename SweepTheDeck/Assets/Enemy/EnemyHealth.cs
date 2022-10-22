using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
<<<<<<< HEAD
=======
    public GameObject deathEffect;
>>>>>>> CharacterDevelopment
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Die animation
        // Make enemy stop doing stuff
<<<<<<< HEAD
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
=======
        /*animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;*/
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
>>>>>>> CharacterDevelopment
    }

}
