using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	private Animator deathAnim;
	public GameObject deathReward;

	// Use this for initialization
	void Start () {
		deathAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) 
		{
			if (deathReward != null) 
			{
				deathAnim.SetBool ("Killed", true);
				Instantiate (deathReward, transform.position, transform.rotation);
			}

			Destroy(gameObject);
		}


	}

	public void GiveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;
	}
}
