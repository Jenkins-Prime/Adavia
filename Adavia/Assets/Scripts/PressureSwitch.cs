using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwitchStates {Timed, Weighted, OneOff}

public class PressureSwitch : MonoBehaviour {
	public SwitchStates switches;
	public bool switchActive;
	private Animator anim;
	public float switchTimer;
	private float initialSwitchTimer;
	private bool timedSwitchActive;

	// Use this for initialization
	void Start () 
	{
		initialSwitchTimer = switchTimer;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timedSwitchActive) 
		{
			switchTimer -= Time.deltaTime;
			if (switchTimer <= 0) 
			{
				switchTimer = 0;
				anim.SetBool ("Active", false);
				timedSwitchActive = false;
				switchActive = false;
				switchTimer = initialSwitchTimer;
				switchActive = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Interactible")
		{
			if (switches == SwitchStates.OneOff) 
			{
				anim.SetBool ("Active", true);
				switchActive = true;
			}

			if (switches == SwitchStates.Weighted) 
			{
				anim.SetBool ("Active", true);
				switchActive = true;
			}
				
			if (switches == SwitchStates.Timed) 
			{
				if (switchTimer > 0) 
				{
					switchActive = true;
					timedSwitchActive = true;
					anim.SetBool ("Active", true);
				} 
				else 
				{
					return;
				}
			}
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (switches == SwitchStates.OneOff) 
		{
			return;
		}

		if (switches == SwitchStates.Weighted) 
		{
			anim.SetBool ("Active", false);
			switchActive = false;
		}
			
	}
}
