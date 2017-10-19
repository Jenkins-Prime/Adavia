using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSwitches : MonoBehaviour {

	public bool crystalActivated;
	private Animator anim;
	public int requiredCrystals;
	public int currentCrystals;
	private CrystalSwitchManager cMan;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		cMan = FindObjectOfType<CrystalSwitchManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentCrystals == requiredCrystals) 
		{
			Debug.Log ("activate object or instantiate reward");
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if (Input.GetKeyDown (KeyCode.E)) 
			{
				if (!crystalActivated) 
				{
					cMan.activatedCrystals++;
				}
				crystalActivated = true;
				anim.SetBool ("Activated", true);

					
			}
		}
	}


}
