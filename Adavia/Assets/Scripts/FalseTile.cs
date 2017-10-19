using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Reaction {Spawn, Activate, Injure}
public class FalseTile : MonoBehaviour {

	[SerializeField]
	private Reaction tileAction; 
	private Animator anim;

	[SerializeField]
	private bool tileActivated;

	[Header("Spawn")]
	[SerializeField]
	private GameObject spawnTarget;
	[SerializeField]
	private Transform spawnLocation;
	[SerializeField]
	private GameObject spawnEffect;

	[Header("Activate")]
	[SerializeField]
	private GameObject activateTarget;

	[Header("Injure")]
	[SerializeField]
	private GameObject injuryAnim;
	[SerializeField]
	private int damageToGive;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (!tileActivated) 
			{
				anim.SetBool ("Active", true);

				if (tileAction == Reaction.Spawn) 
				{
					if (spawnEffect != null) 
					{
						Instantiate (spawnEffect, spawnLocation.transform.position, spawnLocation.transform.rotation);
						Instantiate (spawnTarget, spawnLocation.transform.position, spawnLocation.transform.rotation);
						tileActivated = true;
					} 
					else 
					{
						Instantiate (spawnTarget, spawnLocation.transform.position, spawnLocation.transform.rotation);
						tileActivated = true;
					}
				}

				if (tileAction == Reaction.Activate) 
				{
					tileActivated = true;
				}

				if (tileAction == Reaction.Injure) 
				{
					tileActivated = true;
				}
			
			}


		}

	}

}
