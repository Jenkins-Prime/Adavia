using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPad : MonoBehaviour {

	[TooltipAttribute("What Warp Pad is the player being transported to?")]
	public GameObject targetWarpPad;
	[TooltipAttribute("How long to display the warping animation before transporting?")]
	public float animTime;
	private float initialAnimTime;
	private Animator anim;
	[TooltipAttribute("How far away (to the left or right) from the target pad do you want the player to land?")]
	public float xOffset;
	[TooltipAttribute("How far away (above or below) from the target pad do you want the player to land?")]
	public float yOffset;
	private bool playerOnPad;
	private PlayerMovement player;


	void Start()
	{
		anim = GetComponent<Animator> ();
		initialAnimTime = animTime;
		player = FindObjectOfType<PlayerMovement> ();
	}
	 
	void Update()
	{
		if(playerOnPad)

		animTime--;
		if (animTime <= 0) 
		{
			animTime = 0;
			player.transform.position = new Vector3 (targetWarpPad.transform.position.x + xOffset, targetWarpPad.transform.position.y + yOffset, transform.position.z);
			anim.SetBool ("Active", false);
			animTime = initialAnimTime;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
		playerOnPad = true;
		anim.SetBool ("Active", true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		playerOnPad = false;
		anim.SetBool ("Active", false);
		animTime = initialAnimTime;
	}

  }

