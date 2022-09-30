using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private CharacterController motor;

    [Header("Movement Options")]
    public float moveSpeed = 8.0f;
    public float sprintSpeed = 12.0f;
    public float jumpForce = 5.0f;
    public Camera playerCamera;
    public float gravityMultiplier = 3.0f;

    [Header("Ground Check Options")]
    public float groundRayLength = 1.5f;
    public LayerMask groundMask = ~0;
    private Vector3 groundNormal = Vector3.up;

    [Header("Rotation Options")]
    public float rotationSpeed = 180.0f;

    private Vector3 moveWish;
    private bool jumpWish;
    private bool sprintWish;

    private float yVelocity;

    private Vector3 desiredForward;

    private bool isGrounded;

    public void Teleport(Vector3 newPosition)
    {
        motor.enabled = false;
        transform.position = newPosition;
        motor.enabled = true;
    }

    private void Update()
    {
        moveWish = new Vector3(Input.GetAxisRaw("Horizontal"),
                               0.0f,
                               Input.GetAxisRaw("Vertical"));
        moveWish = Vector3.ClampMagnitude(moveWish, 1);

        jumpWish = jumpWish || Input.GetButtonDown("Jump");
        sprintWish = Input.GetButton("Sprint");

        if(Input.GetKeyDown(KeyCode.R))
        {
            Teleport(new Vector3(0, 1, 0));
        }
    }

    private void FixedUpdate()
    {
        // combine forces
        Vector3 baseMove = moveWish * (sprintWish ? sprintSpeed : moveSpeed);

        if (playerCamera != null)
        {
            baseMove = Quaternion.AngleAxis(playerCamera.transform.rotation.eulerAngles.y, Vector3.up) * baseMove;
        }
        
        // integrate gravity
        yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;

        // check for jump
        bool jumpedThisFrame = false;
        if (jumpWish)
        {
            jumpWish = false;

            if (isGrounded)
            {
                yVelocity = jumpForce;
                isGrounded = false;
                jumpedThisFrame = true;
            }
        }

        // reset yVelocity if grounded
        if (isGrounded)
        {
            yVelocity = Physics.gravity.y * Time.deltaTime;
        }

        Vector3 finalMove = baseMove;

        // reorient the movement onto the current ground normal if grounded
        if(isGrounded)
        {
            finalMove = Vector3.ProjectOnPlane(baseMove, groundNormal);
        }

        // apply the movement to the motor
        CollisionFlags moveFlags = motor.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
        if(jumpedThisFrame)
        {
            // ignore ground collision event if we just jumped
            moveFlags &= ~CollisionFlags.CollidedBelow;
        }
        moveFlags |= motor.Move(finalMove * Time.deltaTime);

        // if, while moving, we bump into something below us...
        if ((CollisionFlags.Below & moveFlags) != 0 || isGrounded)
        {
            if (Physics.Raycast(transform.position,              // location of the start of the ray
                           Vector3.down,                    // direction to shoot the ray in
                           out RaycastHit hit,              // data about the thing that the ray hit
                           groundRayLength,                 // how far (aka the magnitude of the ray)
                           groundMask,                      // which types of objects to hit?
                           QueryTriggerInteraction.Ignore)) // whether we should include or ignore triggers?
            {
                isGrounded = Vector3.Angle(hit.normal, Vector3.up) < motor.slopeLimit;
                groundNormal = hit.normal;
            }
            else
            {
                isGrounded = false;
            }
        }

        // record the direction I want to face
        if (baseMove.magnitude != 0.0f)
        {
            desiredForward = baseMove.normalized;
        }

        // apply the rotation
        transform.forward = Vector3.RotateTowards(transform.forward,    // direction I am currently facing
            desiredForward,                                             // direction I want to face
            rotationSpeed * Mathf.Deg2Rad * Time.deltaTime,             // max change in radians
            0.0f);                                                      // max change in magnitude (none!)
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(transform.position, desiredForward * 5.0f);
    }
}