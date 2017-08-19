using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
	public int healthValue;
	private PlayerHealthManager healthMan;
	public GameObject pickupParticles;

	// Use this for initialization
	void Start () {
		healthMan = FindObjectOfType<PlayerHealthManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			healthMan.AddHealth (healthValue);
			Instantiate (pickupParticles, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
