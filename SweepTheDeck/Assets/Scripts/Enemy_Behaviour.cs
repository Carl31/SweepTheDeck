using UnityEngine;
using System.Collections;
//Example Script for motion (Walk, jump and dying), for dying press 'k'...
public class Enemy_Behaviour : MonoBehaviour
{
	private float maxspeed; //walk speed
	Animator anim;
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
	private float currentHealth = 10;


	//--
	void Start()
	{
		maxspeed = 2f;//Set walk speed
		faceright = true;//Default right side
		anim = this.gameObject.GetComponent<Animator>();
		//anim.SetBool("walk", false);//Walking animation is deactivated
		anim.SetBool("dead", false);//Dying animation is deactivated
		anim.SetBool("jump", false);//Jumping animation is deactivated
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Physics2D.IgnoreLayerCollision(3, 7);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//if (coll.gameObject.tag == "Ground"){//################Important, the floor Tag must be "Ground" to detect the collision!!!!
		jumping = false;
		anim.SetBool("jump", false);
		//}
	}

	void Update()
	{
		cooldownTimer += Time.deltaTime; // increment timer

		//-- Attack animation off
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("attacking"))
		{
		}
		else
		{
			anim.SetBool("attack", false);
		}
		//--
		//Debug.Log ("+---- " + aux);

		//--
		if (isDead == false)
		{
			// UNNECESSARY CODE ... 

			/*//--JUMPING
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("attack", true);
                anim.Play("attacking", -1, 0f);
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (jumping == false)
                {//only once time each jump
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200));
                    jumping = true;
                    anim.SetBool("jump", true);
                }
            }
            //--END JUMPING

            //--WALKING
            float move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed, GetComponent<Rigidbody2D>().velocity.y);
            //--

            if (move > 0)
            {//Go right
                anim.SetBool("walk", true);//Walking animation is activated
                if (faceright == false)
                {
                    Flip();
                }
            }
            if (move == 0)
            {//Stop
                anim.SetBool("walk", false);
            }
            if ((move < 0))
            {//Go left
                anim.SetBool("walk", true);
                if (faceright == true)
                {
                    Flip();
                }
            }
            //END WALKING*/

			//GetComponent<Rigidbody2D>().velocity = movement * maxspeed;
			
			
			
			// MOVEMENT
			if (Vector2.Distance(transform.position, target.position) > attackRange)
			{
				anim.SetBool("walk", true);
				Vector2 tempVec = Vector2.MoveTowards(transform.position, target.position, maxspeed * Time.deltaTime);
				transform.position = tempVec;
				if ((tempVec.x - previousX) > 0 && !faceright) Flip();
				if ((tempVec.x - previousX) < 0 && faceright) Flip();
				Debug.Log("Current: "+tempVec.x);
				previousX = tempVec.x;
			}
			else
			{
				anim.SetBool("walk", false);
				attack();
			}
		}
		else
        {
			die();
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
		
		if (cooldownTimer >= attackCooldown)
        {
			cooldownTimer = 0f;
			anim.SetBool("attack", true);
			anim.Play("attacking", -1, 0f);
		}
		
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

	// Die
	void die()
    {
		if (!isDead)
        {
			anim.SetBool("dead", true);
			isDead = true;
		}
	}

}
