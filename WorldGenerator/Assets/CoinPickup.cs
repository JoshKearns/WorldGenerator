using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinScore;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Coin")) return;
        coinScore++;
        Destroy(other.gameObject);
    }
}
