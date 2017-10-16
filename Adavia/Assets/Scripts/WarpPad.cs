using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPad : MonoBehaviour {

	public GameObject targetWarpPad;
	public float animTime;
	private float initialAnimTime;
	private Animator anim;
	public float xOffset;
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

