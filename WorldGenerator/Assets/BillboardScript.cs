using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(transform.position + _player.transform.rotation * Vector3.forward, _player.transform.rotation * Vector3.up);
        var eulerAngles = transform.eulerAngles;
        eulerAngles.z = 0;
        transform.eulerAngles = eulerAngles;
    }
}
