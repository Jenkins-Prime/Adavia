using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {Left, Right, Up, Down}
public class RollingBallBehaviour : MonoBehaviour {

	[SerializeField]
	private float moveSpeed;
	private Rigidbody2D rb2d;
	[SerializeField]
	private Direction movementDirection;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (movementDirection == Direction.Left) 
		{
			rb2d.velocity = new Vector2 (-moveSpeed, 0);

		}

		if (movementDirection == Direction.Right) 
		{
			rb2d.velocity = new Vector2 (moveSpeed, 0);
		}

		if (movementDirection == Direction.Up) 
		{
			rb2d.velocity = new Vector2 (0, moveSpeed);
		}

		if (movementDirection == Direction.Down) 
		{
			rb2d.velocity = new Vector2 (0, -moveSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag != "Player") 
		{
			Destroy (gameObject);
		}
	}
}
