using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorBehaviour : MonoBehaviour {
	private KeyUI key;
	private Animator anim;
	public bool doorOpen;
	public GameObject unlockParticles;
	private bool instantiated;
	private SpriteRenderer render;

	// Use this for initialization
	void Start () {
		key = FindObjectOfType<KeyUI> ();
		anim = GetComponent<Animator> ();
		render = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (doorOpen) 
		{
			render.sortingOrder = -1;
			if (!instantiated) 
			{
				Instantiate (unlockParticles, transform.position, transform.rotation);
				instantiated = true;
			}

			anim.SetBool ("Open", true);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Garbage Gal") 
		{
			if (key.keySelection >= 1) 
			{
				key.UseKey ();
				doorOpen = true;
			}	
		}
	}
}
