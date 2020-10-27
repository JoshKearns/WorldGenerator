using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanet : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationAngle;
    void Update()
    {
        transform.Rotate(rotationAngle * (rotationSpeed * Time.deltaTime), Space.World);
    }
}
