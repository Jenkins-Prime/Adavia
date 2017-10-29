using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyPickup : MonoBehaviour {

	[SerializeField]
	private int valueAmount;
	private CurrencyManager cMan;

	// Use this for initialization
	void Start () {
		cMan = FindObjectOfType<CurrencyManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			cMan.AddCurrency (valueAmount);
			Destroy (gameObject);
		}
	}
}
