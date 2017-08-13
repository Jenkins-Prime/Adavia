using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour {
	
	public GameObject playerDummy;

	[Header ("Hair")]
	public SpriteRenderer playerHair;
	public Sprite[] playerDummyHairArray;
	private int hairSelector;
	public int hairArrayAmount;
	public Text hairNumber;
	public Animator hairAnim;

	[Header ("Animation Examples")]
	public Animator DummyAnim;


	// Use this for initialization
	void Start () 
	{
		hairArrayAmount = playerDummyHairArray.Length;
		playerHair.sprite = playerDummyHairArray [hairSelector];


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AnimExample(string animName)
	{
		if (animName == "Idle") 
		{
			DummyAnim.SetBool ("Walking", false);
			DummyAnim.SetBool ("Jumping", false);
			DummyAnim.SetBool ("Crouching", false);

		}

		if (animName == "Run") 
		{
			DummyAnim.SetBool ("Walking", true);
			DummyAnim.SetBool ("Jumping", false);
			DummyAnim.SetBool ("Crouching", false);
		}

		if (animName == "Jump") 
		{
			DummyAnim.SetBool ("Walking", false);
			DummyAnim.SetBool ("Jumping", true);
			DummyAnim.SetBool ("Crouching", false);
		}

		if (animName == "Crouch") 
		{
			DummyAnim.SetBool ("Walking", false);
			DummyAnim.SetBool ("Jumping", false);
			DummyAnim.SetBool ("Crouching", true);
		}

		///// Hair //////

		if (animName == "Idle") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", false);
		}

		if (animName == "Run") 
		{
			hairAnim.SetBool ("Walking", true);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", false);
		}

		if (animName == "Jump") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", true);
			hairAnim.SetBool ("Crouching", false);
		}

		if (animName == "Crouch") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", true);
		}


	}

	public void ColorSkin(Image other)
	{
		var playerRender = playerDummy.GetComponent<SpriteRenderer> ();
		playerRender.color = other.color;
	}

	public void ColorHair(Image other)
	{
		playerHair.color = other.color;
	}

	public void ChangeHair(bool left)
	{
		if (left) 
		{
			
			hairSelector--;
			if (hairSelector < 0) 
			{
				hairSelector = hairArrayAmount -1;
			}
			hairNumber.text = "" + hairSelector;

		}

		if (!left) 
		{
			hairSelector++;
			if (hairSelector > hairArrayAmount -1) 
			{
				hairSelector = 0;
			}
			hairNumber.text = "" + hairSelector;
		}

		playerHair.sprite = playerDummyHairArray [hairSelector];
		hairAnim.SetInteger ("Hair Selector", hairSelector);

	
	}
}
