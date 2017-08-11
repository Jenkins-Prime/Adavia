using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour {

	[Header("Amount of keys in level.")]
	public int keyAmount;
	[Space]
	[Header("The images to change.")]
	public Image key1;
	public Image key2;
	public Image key3;
	[Space]
	[Header("Obtained key image.")]
	public Sprite obtainedKey;
	[Header("Unobtained key image.")]
	public Sprite unobtainedKey;
	[Space]
	public int keySelection;

	// Use this for initialization
	void Start () {
		if (keyAmount == 1) 
		{
			key1.enabled = true;
			key2.enabled = false;
			key3.enabled = false;
		}

		if (keyAmount == 2) 
		{
			key1.enabled = true;
			key2.enabled = true;
			key3.enabled = false;
		}

		if (keyAmount == 3) 
		{
			key1.enabled = true;
			key2.enabled = true;
			key3.enabled = true;

		}


	}
	
	public void ObtainKey()
	{
		keySelection++;

		if (keySelection == 1) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = unobtainedKey;
			key3.sprite = unobtainedKey;
		}
		if (keySelection == 2) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = obtainedKey;
			key3.sprite = unobtainedKey;
		}
		if (keySelection == 3) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = obtainedKey;
			key3.sprite = obtainedKey;
		}

		if (keySelection > 3) 
		{
			Debug.Log ("You cheatin' bastard!");
		}

	}

	public void UseKey()
	{
		keySelection--;

		if (keySelection < 0) 
		{
			keySelection = 0;
		}

		if (keySelection == 0) 
		{
			key1.sprite = unobtainedKey;
			key2.sprite = unobtainedKey;
			key3.sprite = unobtainedKey;
		}

		if (keySelection == 1) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = unobtainedKey;
			key3.sprite = unobtainedKey;
		}
		if (keySelection == 2) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = obtainedKey;
			key3.sprite = unobtainedKey;
		}
		if (keySelection == 3) 
		{
			key1.sprite = obtainedKey;
			key2.sprite = obtainedKey;
			key3.sprite = obtainedKey;
		}
	}
}
