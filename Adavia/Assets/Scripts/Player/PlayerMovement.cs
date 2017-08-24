using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rBody;

    [SerializeField]
    private float walkingSpeed;

    private bool isWalking;

    private Vector2 facingDirection;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }




    void Update ()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    private void Movement(float xDirection, float yDirection)
    {
        isWalking = false;

        if (xDirection < 0.0f || xDirection > 0.0f)
        {
            rBody.velocity = new Vector2(xDirection, rBody.velocity.y).normalized * walkingSpeed;
            isWalking = true;
            facingDirection = new Vector2(xDirection, 0.0f);

        }

        if (yDirection < 0.0f || yDirection > 0.0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, yDirection).normalized * walkingSpeed;
            isWalking = true;
            facingDirection = new Vector2(0.0f, yDirection);
        }

        if (xDirection <= 0.0f && xDirection >= 0.0f)
        {
            rBody.velocity = new Vector2(0.0f, rBody.velocity.y);
        }

        if (yDirection <= 0.0f && yDirection >= 0.0f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0.0f);
            
        }

        animator.SetFloat("xSpeed", xDirection);
        animator.SetFloat("ySpeed", yDirection);
        animator.SetFloat("xDirection", facingDirection.x);
        animator.SetFloat("yDirection", facingDirection.y);
        animator.SetBool("isWalking", isWalking);


    }
}
