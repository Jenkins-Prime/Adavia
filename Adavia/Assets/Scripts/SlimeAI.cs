using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour {

	[Header("System Checks & Objects")]
	public Transform wallCheck;
	private float wallCheckRadius = .1f;
	public LayerMask whatIsWall;
	private bool hittingWall;
	private Collider2D coll;
	private EnemySpawner enemySpawn;

	[Header("Movement")]
	public float moveSpeed;
	private bool moveRight;
	private Animator anim;
	private bool canMove;
	private Rigidbody2D rb2d;


	[Header("A.I Timers")]
	public float restingTime;
	public float walkingTime;
	private float initialRestingTime;
	private float initialWalkingTime;

	// Use this for initialization
	void Start () {
		canMove = true;
		moveRight = true;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		coll = GetComponent<Collider2D> ();
		enemySpawn = FindObjectOfType<EnemySpawner> ();
		initialRestingTime = restingTime;
		initialWalkingTime = walkingTime;

	
	}

	void FixedUpdate()
	{
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
	}

	// Update is called once per frame
	void Update () 
	{
		if (hittingWall) 
		{
			moveRight = !moveRight;
		}

		if (canMove) {
			if (moveRight) {
				anim.SetBool ("Moving", true);
				transform.localScale = new Vector3 (1, 1, 1);
				rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
			} else {
				anim.SetBool ("Moving", true);
				transform.localScale = new Vector3 (-1, 1, 1);
				rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
			}
		} 
		else 
		{
			anim.SetBool ("Moving", false);
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}


		if (canMove == true) 
		{
			walkingTime -= Time.deltaTime;
			if (walkingTime <= 0) 
			{
				canMove = false;
				restingTime = initialRestingTime;
			}
		}

		if (canMove == false) 
		{
			restingTime -= Time.deltaTime;
			if (restingTime <= 0) 
			{
				canMove = true;
				walkingTime = initialWalkingTime;
			}
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			canMove = false;
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.gravityScale = 0;
			coll.enabled = false;
			anim.SetBool ("Killed", true);
			if (enemySpawn != null) 
			{
				enemySpawn.enemyIsDead = true;
			}
				
		}
	}

}
