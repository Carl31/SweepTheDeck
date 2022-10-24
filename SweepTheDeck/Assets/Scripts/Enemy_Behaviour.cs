using UnityEngine;
using System.Collections;
//Example Script for motion (Walk, jump and dying), for dying press 'k'...
public class Enemy_Behaviour : MonoBehaviour
{
	public float maxspeed; //walk speed
	public Animator anim;
	private bool faceright; //face side of sprite activated
	private bool jumping = false;
	private bool isDead = false;
	private bool isAttacking = false;
	private string aux = "";

	private float attackRange = 1.3f;
	private Transform target;
	private int attackCooldown = 2;

	private float cooldownTimer = 0f;
	private float previousX = 0;

	public float currentHealth;
	public float MaxHealth = 100;

	private float attackDamage = 40f;
	public Transform attackPoint;

	public HealthbarBehaviour Healthbar;

	public LayerMask playerLayers;

	//--
	void Start()
	{
		currentHealth = MaxHealth;
		Healthbar.SetHealth(currentHealth, MaxHealth);
		maxspeed = 2f;//Set walk speed
		faceright = true;//Default right side
		anim = this.gameObject.GetComponent<Animator>();
		//anim.SetBool("walk", false);//Walking animation is deactivated
		anim.SetBool("IsDead", false);//Dying animation is deactivated
		anim.SetBool("jump", false);//Jumping animation is deactivated

		// getting reference to player object
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		Physics2D.IgnoreLayerCollision(3, 7); // switch around
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground"){//################Important, the floor Tag must be "Ground" to detect the collision!!!!
		jumping = false;
		anim.SetBool("jump", false);
		}
	}

	void Update()
	{
		cooldownTimer += Time.deltaTime; // increment timer

		//-- Attack animation off
		/*if (anim.GetCurrentAnimatorStateInfo(0).IsName("attacking"))
		{
		}
		else
		{
			anim.SetBool("attack", false);
		}*/

		//Debug.Log ("+---- " + aux);

		//--
		if (isDead == false)
		{
			// MOVEMENT
				// to check that target reference isn't null
			if (target == null)
			{
				target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
				if (target == null)
                {
					Debug.Log("NULL TARGET");
				}	
			}
			Physics2D.IgnoreLayerCollision(3, 7);

			Debug.Log("targetpos: " + target);
			if (Vector2.Distance(transform.position, target.position) > attackRange) // if not within attacking range, move toward player
			{
				anim.SetFloat("Speed", maxspeed);
				anim.ResetTrigger("Attack");

				Vector2 tempVec = Vector2.MoveTowards(transform.position, target.position, maxspeed * Time.deltaTime);
				tempVec.y = transform.position.y;
				transform.position = tempVec;
				if ((tempVec.x - previousX) > 0 && !faceright) Flip();
				if ((tempVec.x - previousX) < 0 && faceright) Flip();
				// Debug.Log("Current: "+tempVec.x);
				previousX = tempVec.x;
			}
			else // within attack range, attack player
			{
				anim.SetFloat("Speed", maxspeed);
				attack();
			}
		}
		else
		{ 
			anim.SetBool("IsDead", true);
			maxspeed = 0;
			this.enabled = false;
			Destroy(gameObject);
		}
    }

	void Flip()
	{
		faceright = !faceright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void attack()
    {
		Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

		if (cooldownTimer >= attackCooldown)
		{
			cooldownTimer = 0f;
			anim.SetTrigger("Attack");
			foreach (Collider2D player in hitPlayer)
			{
				player.GetComponent<PlayerMovement>().takeDamage(attackDamage);
			}
		}

	}

	// When enemy takes damage
	public void takeDamage(float damage)
	{
		currentHealth -= damage;
		Healthbar.SetHealth(currentHealth, MaxHealth);
		if (currentHealth <= 0 && isDead == false)
		{
			Debug.Log("Enemy died!");
			isDead = true;
		}
	}
	
	// Die
	void die()
	{
		if (!isDead)
        {
			anim.SetBool("IsDead", true);
			isDead = true;
			maxspeed = 0;
			Destroy(gameObject);
		}
	}

}