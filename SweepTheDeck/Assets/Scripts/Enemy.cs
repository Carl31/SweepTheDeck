using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth { get; }
    int currentHealth { get; set; }
    string name { get; }
    int damage { get; }
    int gold { get; } // number of coins dropped upon death -- need to implement this

    private Enemy(int maxHealth, int damage, string name, int gold)
    {
        this.maxHealth = maxHealth;
        this.damage = damage;
        this.name = name;
        this.currentHealth = maxHealth;
        this.gold = gold;
    }

    public static Enemy CreateEnemy(string type, int difficulty) // difficulty determines health and damage, type determines the type of sprite -- need to implement this
    {
        if (difficulty <= 10 && difficulty >= 1) // need to also check for type -- only "skeletons" and "zombies"?
	    {
            return new Enemy(difficulty * 10, difficulty * 10, type, difficulty * 5);
	    }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        //player hurt animation.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!!!");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
