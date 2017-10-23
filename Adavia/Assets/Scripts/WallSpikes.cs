using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikes : MonoBehaviour {

	[SerializeField]
	private bool isActive;
	[SerializeField]
	private int damageToGive;
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (!isActive) 
			{
				anim.SetBool ("Active", true);
				isActive = true;
			}

			if (isActive) 
			{
				Debug.Log ("You got hit!");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			anim.SetBool ("Active", false);
			isActive = false;
		}
	}

}
