using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	[SerializeField]
	private GameObject pauseMenu;
	public bool isActive;
	[SerializeField]
	private PauseMenuController pMan;



	// Use this for initialization
	void Start () 
	{
		pMan = FindObjectOfType<PauseMenuController> ();
		pauseMenu.SetActive (false);
		isActive = false;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonUp("Cancel")) 
		{
			if (pauseMenu.activeInHierarchy) 
			{
				pauseMenu.SetActive (false);
				isActive = false;
				Time.timeScale = 1;
			
			} 
			else 
			{
				
				pauseMenu.SetActive (true);
				isActive = true;
				Time.timeScale = 0;

			}
		}
	}
}
