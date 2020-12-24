using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool paused;
    public GameObject blindfold;
    
    // Start is called before the first frame update
    void Start()
    {
        paused = true;
    }

    public void TurnOffBlindfold()
    {
        paused = false;
        blindfold.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (!paused)
        {
            // Get controller input
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
            // Calculate move direction
            Vector3 move = transform.right * x + transform.forward * z;
            
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
    }
}
