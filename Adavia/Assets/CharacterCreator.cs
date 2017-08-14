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
	private int hairArrayAmount;
	public Text hairNumber;
	public Animator hairAnim;

	[Header ("Animation Examples")]
	public Animator DummyAnim;
	public int animNumber;

	[Header ("Facial Hair")]
	public SpriteRenderer playerFacialHair;
	public Sprite[] playerFacialHairArray;
	private int facialHairSelector;
	private int facialHairArrayAmount;
	public Text facialHairNumber;
	public Animator facialHairAnim;
	public GameObject facialHairUI;

	[Header ("Glasses")]
	public GameObject GlassesUI;


	// Use this for initialization
	void Start () 
	{
		facialHairArrayAmount = playerFacialHairArray.Length;
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
			animNumber = 0;
		}

		if (animName == "Run") 
		{
			DummyAnim.SetBool ("Walking", true);
			DummyAnim.SetBool ("Jumping", false);
			DummyAnim.SetBool ("Crouching", false);
			animNumber = 1;
		}

		if (animName == "Jump") 
		{
			DummyAnim.SetBool ("Walking", false);
			DummyAnim.SetBool ("Jumping", true);
			DummyAnim.SetBool ("Crouching", false);
			animNumber = 2;
		}

		if (animName == "Crouch") 
		{
			DummyAnim.SetBool ("Walking", false);
			DummyAnim.SetBool ("Jumping", false);
			DummyAnim.SetBool ("Crouching", true);
			animNumber = 3;
		}
	

		///// Hair //////

		if (animName == "Idle") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", false);
			animNumber = 0;
		}

		if (animName == "Run") 
		{
			hairAnim.SetBool ("Walking", true);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", false);
			animNumber = 1;
		}

		if (animName == "Jump") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", true);
			hairAnim.SetBool ("Crouching", false);
			animNumber = 2;
		}

		if (animName == "Crouch") 
		{
			hairAnim.SetBool ("Walking", false);
			hairAnim.SetBool ("Jumping", false);
			hairAnim.SetBool ("Crouching", true);
			animNumber = 3;
		}


	}

	public void ShowFacialHair(bool value)
	{
		if (value == true) 
		{
			facialHairUI.SetActive (true);
			playerFacialHair.gameObject.SetActive (true);
		}

		if (value == false) 
		{
			facialHairUI.SetActive (false);
			playerFacialHair.gameObject.SetActive (false);
		}
	}

	public void ShowGlasses(bool value)
	{
		if (value == true) 
		{
			GlassesUI.SetActive (true);
		}

		if (value == false) 
		{
			GlassesUI.SetActive (false);
		}
	}

	public void ChangeFacialHair(bool left)
	{
		if (left) 
		{

			facialHairSelector--;
			if (facialHairSelector < 0) 
			{
				facialHairSelector = facialHairArrayAmount -1;
			}
			facialHairNumber.text = "" + facialHairSelector;

		}

		if (!left) 
		{
			facialHairSelector++;
			if (facialHairSelector > facialHairArrayAmount -1) 
			{
				facialHairSelector = 0;
			}
			facialHairNumber.text = "" + facialHairSelector;
		}

		playerFacialHair.sprite = playerFacialHairArray [facialHairSelector];
		facialHairAnim.SetInteger ("Facial Hair Selector", facialHairSelector);
		DummyAnim.Play(animNumber, -1, 0f);
		hairAnim.Play (animNumber, -1, 0f);
		facialHairAnim.Play (animNumber, -1, 0f);
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
		DummyAnim.Play(animNumber, -1, 0f);
		hairAnim.Play (animNumber, -1, 0f);
		facialHairAnim.Play (animNumber, -1, 0f);
	}
}
