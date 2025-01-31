﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Look speed
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    
    // Player body reference
    public Transform player;

    private bool _paused;
    private PlayerMovement _playerMovement;
    
    void Start()
    {
        _paused = false;
        _playerMovement = gameObject.transform.parent.GetComponent<PlayerMovement>();
        // Hide cursor
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        _paused = _playerMovement.paused;
        if (!_paused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            // Get controller input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * MenuScript.globalMouse * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * MenuScript.globalMouse * Time.deltaTime;

            // Lock vertical look to 180 Degrees
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
            // Look up & down
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            // Look left & right
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
