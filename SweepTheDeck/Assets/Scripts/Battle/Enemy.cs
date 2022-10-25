using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public GameObject coinPref; // coin prefab

    public GameObject game;

    public bool isDead;
    public int speed;
    public int maxHealth;
    public int currentHealth;
    public string enemyName;
    public int damage;
    public int gold; // number of coins dropped upon death -- need to implement this

    public Enemy(int speed, int maxHealth, int damage, string name, int gold)
    {
        this.speed = speed;
        this.maxHealth = maxHealth;
        this.damage = damage;
        this.enemyName = name;
        this.currentHealth = maxHealth;
        this.gold = gold;
        this.isDead = false;
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

        for (int i = 0; i < 4; i++)
        {
            Instantiate(coinPref, transform.position, Quaternion.identity);
            coinPref.transform.localScale = new Vector3(7f, 7f, 0.0f);
        }
        

        Debug.Log("Coin spawned");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        this.isDead = true;

    }

    public override string ToString()
    {
        return enemyName + ": " + speed + "(speed), " + maxHealth + "(health), " + damage + "(damage)";
    }

    /*void Update()
    {
        Debug.Log(IsCoin());
    }*/

    bool IsCoin() // returns if there are any more coins
    {
        GameObject[] tempArr = GameObject.FindGameObjectsWithTag("Coin");
        if (tempArr.Length == 0)
        {
            return false; // no enemies exist
        }

        return true;
    }
}
