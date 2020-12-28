using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public AnchorLook TargetAnchor;
    public CharacterController controller;

    // Update is called once per frame
    public float walkingSpeed = 6.0f;
    public float jumpHeight = 5.0f;
    public float gravity = 9.81f;
    private Vector3 movement;
    private Vector3 jumpVelocity = Vector3.zero;
    private float airSpeed = 4.0f;
    private float airFriction = 0.65f;
    private float alomanticConstant = 20f;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, 0, z);
        movement = transform.TransformDirection(movement);
        if (controller.isGrounded)
        {
            controller.slopeLimit = 45.0f;
            movement *= walkingSpeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = movement * airFriction;
                jumpVelocity.y = jumpHeight;
                controller.slopeLimit = 90.0f;
            }
            else
            {
                jumpVelocity = Vector3.zero;
            }
        }
        else
        {
            movement *= airSpeed;
        }

        if (TargetAnchor != null && Input.GetKey(KeyCode.E))
        {
            var pullVector = (TargetAnchor.transform.position - transform.position).normalized;
            jumpVelocity = (jumpVelocity * .25f + pullVector * .75f).normalized * alomanticConstant;
        }
        if (TargetAnchor != null && Input.GetKey(KeyCode.R))
        {
            var pushVector = (TargetAnchor.transform.position - transform.position).normalized * -1f;
            jumpVelocity = (jumpVelocity * .25f +  pushVector * .75f).normalized * alomanticConstant;
        }

        jumpVelocity.y -= gravity * Time.deltaTime;
        controller.Move((movement + jumpVelocity) * Time.deltaTime);
    }
}
