using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Wall")) return;
        var toDestroy = other.transform.parent;
        Destroy(toDestroy.gameObject);
    }

    public void DestroySpawn()
    {
        Destroy(gameObject);
    }
}
