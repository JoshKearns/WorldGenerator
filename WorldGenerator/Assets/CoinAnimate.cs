using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimate : MonoBehaviour
{
    public Sprite[] coinSprites;
    private SpriteRenderer _rend;
    private int _counter = 0;

    private void Start()
    {
        _rend = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(CoinAnimateFunction());
    }

    IEnumerator CoinAnimateFunction()
    {
        if (_counter < coinSprites.Length - 1)
            _counter++;
        else
            _counter = 0;
        yield return new WaitForSeconds(.1f);
        _rend.sprite = coinSprites[_counter];
        StartCoroutine(CoinAnimateFunction());
    }
}
