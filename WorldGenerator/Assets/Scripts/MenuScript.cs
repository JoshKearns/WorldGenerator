using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Slider hSlider;
    public Slider vSlider;

    public Slider mouseSensitivity;

    public Text hText;
    public Text vText;
    public Text mText;


    public static int globalXValue = 10;
    public static int globalYValue = 10;
    public static float globalMouse = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        
        hSlider.value = globalXValue;
        vSlider.value = globalYValue;
        mouseSensitivity.value = globalMouse;
    }

    private void Update()
    {
        hText.text = hSlider.value.ToString();
        vText.text = vSlider.value.ToString();
        mText.text = mouseSensitivity.value.ToString("#.##");
    }


    public void StartGame()
    {
        globalXValue = (int)hSlider.value;
        globalYValue = (int)vSlider.value;
        globalMouse = mouseSensitivity.value;
        
        SceneManager.LoadScene("Maze");
    }
}
