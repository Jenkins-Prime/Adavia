using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour {
	private KeyUI keyUI;

	void Start()
	{
		keyUI = FindObjectOfType<KeyUI> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			keyUI.ObtainKey ();
			Destroy (gameObject);
		}
	}
}
