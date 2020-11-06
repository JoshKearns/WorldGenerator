using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanet : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationAngle;

    public GameObject sun;
    public float rotationSpeedAroundSun;
    
    void Update()
    {
        transform.Rotate(rotationAngle * (rotationSpeed * Time.deltaTime), Space.World);
        
        transform.RotateAround(sun.transform.position, Vector3.up, rotationSpeedAroundSun * Time.deltaTime);
    }
}
