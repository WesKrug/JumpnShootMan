using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float Gravity = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public AnchorLook TargetAnchor;
    public Vector3 Velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (isGrounded && Velocity.y < 0)
            Velocity.y = -2f;

        if (Input.GetKey(KeyCode.Space))
        {
            Velocity.y = 0f;
            controller.Move(new Vector3(0, transform.forward.y + speed * Time.deltaTime));
        }

        if (TargetAnchor != null && Input.GetKey(KeyCode.Mouse0))
        {
            var toAnchor = (transform.position - TargetAnchor.transform.position).normalized;
            controller.Move(toAnchor *= .5f);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);

        //controller.Move(controller.velocity * Time.deltaTime);

        Velocity.y += Math.Min(Gravity * Time.deltaTime, -9.81f);

        controller.Move(Velocity * Time.deltaTime);
    }
}
