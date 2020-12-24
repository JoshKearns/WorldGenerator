using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Replay()
    {
        SceneManager.LoadScene("Menu");
    }
}
