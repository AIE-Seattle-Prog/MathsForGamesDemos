using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private CharacterController motor;

    public float moveSpeed = 8.0f;
    public float jumpForce = 5.0f;
    public float groundRayLength = 1.5f;
    public LayerMask groundMask = ~0;

    private Vector3 moveWish;
    private bool jumpWish;
    private float yVelocity;

    private void Update()
    {
        moveWish = new Vector3(Input.GetAxisRaw("Horizontal"),
                               0.0f,
                               Input.GetAxisRaw("Vertical"));
        jumpWish = jumpWish || Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        // combine forces
        Vector3 baseMove = moveWish * moveSpeed;
        yVelocity += Physics.gravity.y * Time.deltaTime;

        // reset yVelocity if grounded
        if (motor.isGrounded)
        {
            yVelocity = Physics.gravity.y * Time.deltaTime;
        }

        // check for jump
        if (jumpWish)
        {
            jumpWish = false;

            if (motor.isGrounded)
            {
                yVelocity = jumpForce;
            }
        }

        // reorient the movement onto the current ground normal
        if(Physics.Raycast(transform.position,              // location of the start of the ray
                           Vector3.down,                    // direction to shoot the ray in
                           out RaycastHit hit,              // data about the thing that the ray hit
                           groundRayLength,                 // how far (aka the magnitude of the ray)
                           groundMask,                      // which types of objects to hit?
                           QueryTriggerInteraction.Ignore)) // whether we should include or ignore triggers?
        {
            baseMove = Vector3.ProjectOnPlane(baseMove, hit.normal);
        }

        // apply the movement to the motor
        motor.Move(baseMove * Time.deltaTime);
        motor.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
    }
}
