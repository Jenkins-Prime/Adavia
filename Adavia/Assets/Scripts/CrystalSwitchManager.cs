using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSwitchManager : MonoBehaviour {

	public int activatedCrystals;
	public int requiredCrystals;

	
	// Update is called once per frame
	void Update () 
	{
		if (activatedCrystals == requiredCrystals) 
		{
			Debug.Log ("Required Crystals activated!");
		}
	}
}
