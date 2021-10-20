using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float movement_speed = 5f;

    Vector3 move_vec;

    public CharacterController controller;
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        float z_input = Input.GetAxisRaw("Vertical");
        float x_input = Input.GetAxisRaw("Horizontal");

        Vector3 move = transform.right * x_input + transform.forward * z_input;
        move = move.normalized;
        controller.Move(move * movement_speed * Time.deltaTime);
    }
}
