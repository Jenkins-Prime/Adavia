using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallEmitter : MonoBehaviour {

	[SerializeField]
	private GameObject ball; 
	[SerializeField]
	private float emissionSpeed;
	private float initialEmissionSpeed;
	[SerializeField]
	private Transform emissionLocation;
	public bool Active;

	// Use this for initialization
	void Start () {
		initialEmissionSpeed = emissionSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Active) 
		{
			emissionSpeed -= Time.deltaTime;
			if (emissionSpeed <= 0) {
				emissionSpeed = initialEmissionSpeed;
				Instantiate (ball, emissionLocation.position, emissionLocation.rotation);
			}
		}
	}
}
