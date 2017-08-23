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

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate ()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

	}

    private void Movement(float xDirection, float yDirection)
    {
        
        if (xDirection < 0.5f || xDirection > -0.5f)
        {
            rBody.velocity = new Vector2(xDirection, rBody.velocity.y).normalized * walkingSpeed;
            isWalking = true;
            
        }

        if (yDirection < 0.5f || yDirection > -0.5f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, yDirection).normalized * walkingSpeed;
            isWalking = true;
            
        }

        if (xDirection < 0.5f && xDirection > -0.5f)
        {
            rBody.velocity = new Vector2(0.0f, rBody.velocity.y);
            isWalking = false;
        }

        if (yDirection < 0.5f && yDirection > -0.5f)
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 0.0f);
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            animator.SetFloat("xSpeed", xDirection);
            animator.SetFloat("ySpeed", yDirection);
        }
    }
}
