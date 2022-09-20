using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float currentHealth;
    private bool isDead;

    public void initHealth(float health)
    {
        currentHealth = health;
        isDead = false;
    }

    // When enemy takes damage
    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && isDead == false)
        {
            Debug.Log("Enemy died!");
            isDead = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initHealth(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press space bar to "hit" enemy - this needs to be updated when main character can attack
        {
            TakeDamage(2);
            Debug.Log("Enemy taken hit! Current health: " + this.currentHealth);
        }
    }
}
