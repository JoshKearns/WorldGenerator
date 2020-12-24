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

    public Text hText;
    public Text vText;


    public static int globalXValue = 10;
    public static int globalYValue = 10;

    private void Start()
    {
        hSlider.value = globalXValue;
        vSlider.value = globalYValue;
    }

    private void Update()
    {
        hText.text = hSlider.value.ToString();
        vText.text = vSlider.value.ToString();
    }


    public void StartGame()
    {
        globalXValue = (int)hSlider.value;
        globalYValue = (int)vSlider.value;
        
        SceneManager.LoadScene("Maze");
    }
}
