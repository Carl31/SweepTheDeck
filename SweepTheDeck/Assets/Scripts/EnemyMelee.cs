using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Veriables
    private float meleeCooldown;
    private int meleeDamage;
    private float cooldownTimer; // timer for cooldown time between attacks
    
    private float attackDistance; // min distance for attack
    private float distanceFromTarget; // stores distance from enemy and player
    private bool cooling; // check if enemy is cooling after attack
    private GameObject target; // the target of enemy attack
    private bool isAttacking;
    private int timer; // timer for seconds between attacks
    private int timerInt; // seconds between attacks (that timer adheres to)
    #endregion

    private void initEnemy()
    {
        meleeCooldown = 2;
        meleeDamage = 2;
        attackDistance = 2;
        cooldownTimer = 2;
        timer = 2;
        cooling = false;
        distanceFromTarget = null;
        target = null;
        isAttacking = false;
        timer = timerInt;
    }

    // Start is called before the first frame update
    void Start()
    {
        initEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromTarget = Vector2.Distance(transform.position, target.transform.position);
        cooldownTimer += Time.deltaTime; // increment timer

        // Can only attack when in range of player and cooldown is finished...
        if (playerInRange())
        {
            if ((cooldownTimer >= meleeCooldown) && !cooling)
            {
                attack(); // attack player
            }
        }
        else
        {
            move(); // move toward player
        }

        if (cooling)
        {
            // TO DO: stop attack animation
            coolDown();
        }
    }

    // returns if player is in melee range of enemy
    private bool playerInRange()
    {
        if (distanceFromTarget < attackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void onInRangeTrigger(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
        }
    }

    private void move()
    {
        // TO DO: start walking animation 

        // if currently not attacking, move toward player -- if (!anim.GetCurretnAnimatorStateInfo(0).IsName("InsertAttackAnimNameHere")) {
        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y); // store x coord of player/target
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * cooldownTimer.deltaTime);
        // }
    }

    private void attack()
    {
        cooldownTimer = 0;
        isAttacking = true;
        // TO DO: stop walking animation
        // TO DO: start attack animation
        
        // TO DO: apply damage to target/player -- target.takeDamage(meleeDamage);
    }

    private void stopAttack()
    {
        cooling = false;
        isAttacking = false;
        // TO DO: stop attack animation

    }

    private void coolDown()
    {
        timer -= Time.deltaTime; // update timer 

        // to add time between attacks (so enemy cannot attack as soon as cooldown is finished)...
        if (timer <= 0 && cooling && isAttacking)
        {
            cooling = false;
            timer = timerInt; // resets timer
        }
    }
}
