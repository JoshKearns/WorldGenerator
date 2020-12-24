using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinPickup : MonoBehaviour
{
    public int coinScore;

    private Maze _mazeScript;

    private AudioSource _audio;

    private void Start()
    {
        _mazeScript = GameObject.FindGameObjectWithTag("Maze").GetComponent<Maze>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (coinScore == _mazeScript.numberOfCoins)
            SceneManager.LoadScene("Win");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Coin")) return;
        coinScore++;
        _audio.Play();
        Destroy(other.gameObject);
    }
}
