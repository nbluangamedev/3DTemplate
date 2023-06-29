using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    public float jumpHeight;
    public float gravity;
    public float stepDown;
    public float airControl;
    public float jumpDamp;

    private Animator animator;
    private CharacterController characterController;
    private Vector2 userInput;
    private Vector3 rootMotion;
    private Vector3 velocity;
    private bool isJumping;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        userInput.x = Input.GetAxis("Horizontal");
        userInput.y = Input.GetAxis("Vertical");

        animator.SetFloat("inputX", userInput.x);
        animator.SetFloat("inputY", userInput.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            velocity.y -= gravity * Time.deltaTime;
            Vector3 airMovement = velocity * Time.fixedDeltaTime;
            airMovement += CalculateAirControl();
            characterController.Move(airMovement);
            isJumping = !characterController.isGrounded;
            rootMotion = Vector3.zero;
        }
        else
        {
            characterController.Move(rootMotion + Vector3.down * stepDown);
            rootMotion = Vector3.zero;

            if(!characterController.isGrounded)
            {
                isJumping = true;
                velocity = animator.velocity * jumpDamp;
                velocity.y = 0;
            }
        }
    }

    private void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition;
    }

    private void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            velocity = animator.velocity * jumpDamp;
            velocity.y = Mathf.Sqrt(2 * gravity * jumpHeight);
        }
    }

    private Vector3 CalculateAirControl()
    {
        return ((transform.forward * userInput.y) + (transform.right * userInput.x)) * (airControl / 100);
    }
}