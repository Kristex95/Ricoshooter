using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using System;

public class Player_Movement : NetworkBehaviour
{
    public float movement_speed = 5f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.005f;
    public LayerMask groundMask;

    public Camera cam;

    Vector3 velocity;
    bool isGrounded;

    public CharacterController controller;
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (IsLocalPlayer)
        {
            
        }
        else
        {
            cam.enabled = false;
        }
    }

    private void Update()
    {
        if (IsLocalPlayer)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            Move();
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            velocity.y = 5f;
        }

    }

    private void Move()
    {
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }

        float z_input = Input.GetAxisRaw("Vertical");
        float x_input = Input.GetAxisRaw("Horizontal");

        Vector3 move = transform.right * x_input + transform.forward * z_input;
        move = move.normalized;
        controller.Move(move * movement_speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
