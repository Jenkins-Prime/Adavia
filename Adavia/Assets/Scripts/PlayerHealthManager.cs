using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {
	[Header ("The player's current health.")]

	public int playerHealth;
	[Header ("The maximum health the player can have.")]

	public int maxPlayerHealth;
	[Header ("The rim around the HP bar.")]
	public Image healthBarRim;

	[Header ("The actual health bar.")]
	public Slider healthBar;


	// Use this for initialization
	void Start () {
		healthBar = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = maxPlayerHealth;
		healthBar.value = playerHealth;

	}

	public void AddHealth(int healthToGive)
	{
		playerHealth += healthToGive;
		if (playerHealth > maxPlayerHealth) 
		{
			playerHealth = maxPlayerHealth;
		}
	}


}
