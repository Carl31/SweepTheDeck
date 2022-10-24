using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public GameObject enemyPrefab = new GameObject();

    public int speed;
    public int maxHealth;
    public int currentHealth;
    public string name;
    public int damage;
    public int gold; // number of coins dropped upon death -- need to implement this

    public Enemy(int speed, int maxHealth, int damage, string name, int gold)
    {
        this.speed = speed;
        this.maxHealth = maxHealth;
        this.damage = damage;
        this.name = name;
        this.currentHealth = maxHealth;
        this.gold = gold;
    }

    /*public Enemy CreateEnemy(string type, int difficulty) // difficulty determines health and damage, type determines the type of sprite -- need to implement this
    {
        if (difficulty <= 10 && difficulty >= 1) // need to also check for type -- only "skeletons" and "zombies"?
        {
            return new Enemy(2, difficulty * 10, difficulty * 10, type, difficulty * 5);
        }
        return null;
    }*/

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

    public override string ToString()
    {
        return name+": " + speed + "(speed), " + maxHealth + "(health), " + damage + "(damage)";
    }
}
