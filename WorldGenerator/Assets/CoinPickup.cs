using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinScore;

    private Maze _mazeScript;

    private void Start()
    {
        _mazeScript = GameObject.FindGameObjectWithTag("Maze").GetComponent<Maze>();
    }

    private void Update()
    {
        if (coinScore == _mazeScript.numberOfCoins)
        {Debug.Log("Win");}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Coin")) return;
        coinScore++;
        Destroy(other.gameObject);
    }
}
