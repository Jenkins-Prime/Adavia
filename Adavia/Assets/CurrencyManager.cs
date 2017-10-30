using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

	[SerializeField]
	private GameObject currencyObject;
	[SerializeField]
	private CanvasGroup canGroup;
	[SerializeField]
	private int currencyAmount;
	[SerializeField]
	private Text text;
	private float fadeOutTime = 3;
	private float timeBeforeFade = 3;
	private float initialBeforeFade;



	// Use this for initialization
	void Start () {
		currencyObject.SetActive (false);
		initialBeforeFade = timeBeforeFade;


	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "" + currencyAmount;
		if (currencyObject.activeInHierarchy) 
		{
			timeBeforeFade -= Time.deltaTime;
			if (timeBeforeFade <= 0) 
			{
				canGroup.alpha -= Time.deltaTime / fadeOutTime;
				if (canGroup.alpha <= 0) 
				{
					currencyObject.SetActive (false);
					timeBeforeFade = initialBeforeFade;
				}

			} 
		}
	}

	public void AddCurrency(int amountToAdd)
	{
		HUDFlash ();
		currencyAmount += amountToAdd;
	}

	private void HUDFlash()
	{
		canGroup.alpha = 1;
		currencyObject.SetActive (true);

	}
}
