using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Movement")]
	public float moveSpeed;
	public float jumpHeight;
	public bool isCrouching;
	private Animator anim;
	private Rigidbody2D rb2d;
	public bool canMove;

	[Header("Checking For Ground")]
	public LayerMask ground;
	public Transform groundCheck;
	public bool onGround;
	private float onGroundradius = 0.2f;

	[Header("Lighting")]
	private Light playerLight;
	private DayAndNight dnN;

	[Header("Character Creation")]
	public bool inCreation;
	public Animator hairAnim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		dnN = FindObjectOfType<DayAndNight> ();
		playerLight = GetComponentInChildren<Light> ();
	}

	void FixedUpdate()
	{
		onGround = Physics2D.OverlapCircle (groundCheck.position, onGroundradius, ground);
	}

	// Update is called once per frame
	void Update () 
	{
		if (canMove) 
		{
		    GroundCheck ();

			Movement ();

			MovementAnim ();
		
			if (Input.GetButtonDown ("Jump")) {
				Jump ();
			}
			
			Crouch ();
		}
		LightCheck ();

		if (inCreation) 
		{
			return;
		}


		
	}
		
	void HairAnim()
	{
		if (hairAnim != null) 
		{
			var movingBool = anim.GetBool ("Moving");
			var jumpingBool = anim.GetBool ("Jumping");
			var crouchBool = anim.GetBool ("Crouching");
			hairAnim.SetBool ("Moving", movingBool);
			hairAnim.SetBool ("Jumping", jumpingBool);
			hairAnim.SetBool ("Crouching", crouchBool);
		}
	}

	void MovementAnim()
	{
		if (Input.GetAxis ("Horizontal") != 0 && onGround) {
			anim.SetBool ("Walking", true);
		} else 
		{
			anim.SetBool ("Walking", false);
		}
	}

	void Movement()
	{
		if (Input.GetAxis ("Horizontal") > 0 && !isCrouching) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
			rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetAxis ("Horizontal") < 0 && !isCrouching) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
			rb2d.velocity = new Vector2 (-moveSpeed, rb2d.velocity.y);
		}

		if (Input.GetAxis ("Horizontal") == 0) 
		{
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
		}
			
	}

	void GroundCheck()
	{
		if (!onGround) {
			anim.SetBool ("Jumping", true);
		} else 
		{
			anim.SetBool ("Jumping", false);
		}
	}
		
	void Jump()
	{
		if (onGround && !isCrouching) 
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpHeight);
		}

		else
		{
			return;
		}
	}

	void Crouch()
	{
		if (Input.GetAxis ("Vertical") < 0 && onGround) {

			anim.SetBool ("Crouching", true);
			isCrouching = true;
		} else 
		{
			anim.SetBool ("Crouching", false);
			isCrouching = false;
		}

	}

	void LightCheck()
	{
		if (dnN != null) 
		{
			if (dnN.isDay) {
				playerLight.enabled = false;
			} else {
				playerLight.enabled = true;
			}
		}
	}
}
