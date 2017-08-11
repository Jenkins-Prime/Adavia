using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public float respawnCountdown;
	public bool enemyIsDead;
	private float initialRespawnCountdown;
	private int enemySelector;

	// Use this for initialization
	void Start () {
		initialRespawnCountdown = respawnCountdown;
		enemyIsDead = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyIsDead) {
			respawnCountdown -= Time.deltaTime;
			if (respawnCountdown <= 0) {
				enemySelector = Random.Range (0, enemies.Length);
				Instantiate (enemies [enemySelector], transform.position, transform.rotation);
				respawnCountdown = initialRespawnCountdown;
				enemyIsDead = false;
			}
		} else 
		{
			return;
		}
	}
}
