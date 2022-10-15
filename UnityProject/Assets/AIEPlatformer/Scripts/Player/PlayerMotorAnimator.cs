using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorAnimator : MonoBehaviour
{
    public PlayerMotor motor;
    public Animator animator;

    private void Start()
    {
        motor.OnJumped.AddListener(HandleMotorJump);
    }

    void Update()
    {
        // get the horizontal movement speed of my character
        Vector3 hMove = motor.Velocity;
        hMove.y = 0.0f;

        // and give it to the animator
        animator.SetFloat("Speed", hMove.magnitude);

        animator.SetBool("IsGrounded", motor.isGrounded);
    }

    private void HandleMotorJump()
    {
        animator.SetTrigger("Jump");
    }
}
