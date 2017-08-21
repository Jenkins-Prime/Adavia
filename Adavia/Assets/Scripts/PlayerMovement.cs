using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private float walkingSpeed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
        Movement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    private void Movement(float xDirection, float yDirection)
    {


        bool isWalking = Mathf.Abs(xDirection) + Mathf.Abs(yDirection) > 0;

        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            animator.SetFloat("xSpeed", xDirection);
            animator.SetFloat("ySpeed", yDirection);

            transform.position += new Vector3(xDirection, yDirection, 0.0f).normalized * Time.deltaTime * walkingSpeed;
        }

    }
}
