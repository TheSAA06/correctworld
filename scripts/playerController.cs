using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController playerBody;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float groundDist = 0.4f;
    Vector3 velocity;

    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        playerBody.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        playerBody.Move(velocity * Time.deltaTime);
    }
}
