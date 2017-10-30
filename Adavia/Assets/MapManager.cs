using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	[SerializeField]
	private GameObject mapCanvas;
	[SerializeField]
	private PauseManager pause;
	public bool mapOpen;

	// Use this for initialization
	void Start () {
		pause = FindObjectOfType<PauseManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.M)) 
		{
			if (!pause.isActive) 
			{
				if (mapCanvas.activeInHierarchy) {
					mapCanvas.SetActive (false);
					Time.timeScale = 1;
					mapOpen = false;
				} else {
					mapCanvas.SetActive (true);
					Time.timeScale = 0;
					mapOpen = true;
				}
			}
		}
	}
}
