using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour {

	[SerializeField]
	private float inactiveTime;
	[SerializeField]
	private float activeTime;

	[SerializeField]
	private bool active;

	private float initialInactiveTime;
	private float initialActiveTime;

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		initialActiveTime = activeTime;
		initialInactiveTime = inactiveTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!active) 
		{
			anim.SetBool ("Active", false);
			inactiveTime -= Time.deltaTime;
			if (inactiveTime <= 0) 
			{
				active = true;
				inactiveTime = initialInactiveTime;
			}

		}

		if (active) 
		{
			anim.SetBool ("Active", true);
			activeTime -= Time.deltaTime;
			if (activeTime <= 0) 
			{
				active = false;
				activeTime = initialActiveTime;
			}

		}

	}
}
