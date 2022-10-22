using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15;
    public float gravity = -10;
    public float jumpHeight = 10;

    public Transform groundCheck;
    public float groundRange = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGround;

    void Update()
    {

        isGround = Physics.CheckSphere(groundCheck.position, groundRange, groundMask);

        if(isGround == true && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
