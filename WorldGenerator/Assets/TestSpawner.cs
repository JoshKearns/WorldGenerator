using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject testCube;
    public int numberOfTests;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            transform.rotation = Random.rotation;
            var _startPos = transform.position + (transform.forward * 110);
            var lookAtAngle = transform.position;
        
            var cube = Instantiate(testCube, _startPos, Quaternion.identity);
            cube.transform.LookAt(lookAtAngle);
            cube.GetComponent<TestSpawnPlacement>().parentObject = gameObject;
        }
    }

}
