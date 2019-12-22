using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMovement : MonoBehaviour
{
    
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private LayerMask groundMask;

    [Space]

    [Header("Reference")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundCheckTransform;

    private bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        MoveInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    float x;
    float z;
    Vector3 velocity;

    void Move()
    {
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundDistance, groundMask);

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }

    void MoveInputs()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

}
