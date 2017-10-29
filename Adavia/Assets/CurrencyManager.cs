using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {
	[SerializeField]
	private int currencyAmount;
	[SerializeField]
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + currencyAmount;
	}

	public void AddCurrency(int amountToAdd)
	{
		currencyAmount += amountToAdd;
	}
}
