using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour {

	[Header("System Checks & Objects")]
	public Transform wallCheck;
	private float wallCheckRadius = .1f;
	public LayerMask whatIsWall;
	private bool hittingWall;
	 
	public Transform groundCheck;
	public float groundCheckRadius = .1f;
	public LayerMask whatIsGround;
	private bool grounded;




	[Header("Movement")]
	public float moveSpeed;
	private bool moveRight;
	private Animator anim;
	private bool canMove;
	private Rigidbody2D body2d;


	[Header("A.I Timers")]
	public float restingTime;
	public float walkingTime;
	private float initialRestingTime;
	private float initialWalkingTime;


	// Use this for initialization
	void Start () {
		
		canMove = true;
		body2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		initialRestingTime = restingTime;
		initialWalkingTime = walkingTime;

	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
	}
	// Update is called once per frame
	void Update () 
	{
		if (!grounded) {
			anim.SetBool ("Jumping", true);
		} 
		else 
		{
			anim.SetBool ("Jumping", false);
		}

		if (canMove) {
			hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

			if (hittingWall)
				moveRight = !moveRight;

			if (moveRight) {
				anim.SetBool ("Moving", true);
				transform.localScale = new Vector3 (1, 1, 1);
				body2d.velocity = new Vector2 (moveSpeed, body2d.velocity.y);
			} else {
				anim.SetBool ("Moving", true);
				transform.localScale = new Vector3 (-1, 1, 1);
				body2d.velocity = new Vector2 (-moveSpeed, body2d.velocity.y);
			}


		} else 
		{
			anim.SetBool ("Moving", false);
			body2d.velocity = new Vector2 (0, body2d.velocity.y);
		}
	


		if (canMove == true) 
		{
			walkingTime -= Time.deltaTime;
			if (walkingTime <= 0) {
				canMove = false;
				restingTime = initialRestingTime;
			}

		}


		if (canMove == false) 
		{ 
			restingTime -= Time.deltaTime;
			if (restingTime <= 0) {
				canMove = true;
				walkingTime = initialWalkingTime;
			}
		}


	}
}