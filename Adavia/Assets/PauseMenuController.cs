using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	[SerializeField]
	public int index;
	[SerializeField]
	private GameObject pointer;
	[SerializeField]
	private Transform[] menuTransforms;
	[SerializeField]
	private GameObject[] Menus;

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyUp (KeyCode.S)) 
		{
			UpdateCursor (true, 1);
		}

		if (Input.GetKeyUp (KeyCode.W)) 
		{
			UpdateCursor (false, 1);
		}

		UpdateMenu();
	
    }

	void UpdateCursor(bool DoesIncreaseIndex, int amount)
	{
		if (DoesIncreaseIndex) 
		{
			if(index == 4)
			{
				index = 0;
			}
			else
			{
				index++;
			}
		}

		if (!DoesIncreaseIndex) 
		{
			if(index == 0)
			{
				index =  4;
			}
			else
			{
				index--;
			}
		}

		pointer.transform.position = menuTransforms [index].transform.position;
	}

	void UpdateMenu ()
	{ 
			if (index == 0) {
				Menus [0].SetActive (true);
				Menus [1].SetActive (false);
				Menus [2].SetActive (false);
				Menus [3].SetActive (false);
				Menus [4].SetActive (false);
			}

			if (index == 1) {
				Menus [0].SetActive (false);
				Menus [1].SetActive (true);
				Menus [2].SetActive (false);
				Menus [3].SetActive (false);
				Menus [4].SetActive (false);
			}

			if (index == 2) {
				Menus [0].SetActive (false);
				Menus [1].SetActive (false);
				Menus [2].SetActive (true);
				Menus [3].SetActive (false);
				Menus [4].SetActive (false);
			}

			if (index == 3) {
				Menus [0].SetActive (false);
				Menus [1].SetActive (false);
				Menus [2].SetActive (false);
				Menus [3].SetActive (true);
				Menus [4].SetActive (false);
			}

			if (index == 4) {
				Menus [0].SetActive (false);
				Menus [1].SetActive (false);
				Menus [2].SetActive (false);
				Menus [3].SetActive (false);
				Menus [4].SetActive (true);
			}

	}
}
