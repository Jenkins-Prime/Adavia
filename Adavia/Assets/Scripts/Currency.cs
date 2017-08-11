using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {
	public int pointWorth;
	public GameObject collectionParticles;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if(collectionParticles != null)
			{
			Instantiate (collectionParticles, transform.position, transform.rotation);
			}
			ScoreManager.AddPoints (pointWorth);
			Destroy (gameObject);
		}
	}
}
