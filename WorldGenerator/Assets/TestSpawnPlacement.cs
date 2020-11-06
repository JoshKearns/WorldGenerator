using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnPlacement : MonoBehaviour
{
    private bool _placed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime;

        if (!_placed)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //Debug.Log(hit.point);

                transform.position = hit.point;
                _placed = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
        }
        else
        {
            GetComponent<TestSpawnPlacement>().enabled = false;
        }
    }
}
