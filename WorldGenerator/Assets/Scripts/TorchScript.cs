using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TorchScript : MonoBehaviour
{
    public GameObject torchOne;
    public GameObject torchTwo;

    private void Start()
    {
        var randomNumber = Random.Range(0, 10);
        if (randomNumber <= 2) return;
        torchOne.SetActive(false);
        torchTwo.SetActive(false);
    }
}
