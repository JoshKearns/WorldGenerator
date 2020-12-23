using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement
    public CharacterController controller;
    public float speed = 12;
    public float jumpHeight = 3f;

    // Ground check
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // Gravity
    public float gravity = -9.81f;
    private Vector3 velocity;
    
    //Under Water
    public bool underWater = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get controller input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
            // Calculate move direction
            Vector3 move = transform.right * x + transform.forward * z;
            
            if (!underWater)
            {
                // Ground check
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
                // Reset Velocity if grounded
                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                }
                
                // Gravity
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity* Time.deltaTime);
                
                // Jump
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
                
                // Movement
                controller.Move(move * speed * Time.deltaTime);
            }
            else
            {
                // Movement
                controller.Move((move *.75f) * speed * Time.deltaTime);

                // Gravity
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity /2 * Time.deltaTime);
        
                // Jump
                if (Input.GetButton("Jump"))
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            underWater = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            underWater = false;
        }
    }
}
