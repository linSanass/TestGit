using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Text PlayercurrentHealthTxt;

    public Slider PlayercurrentHealthSlider;

    public static int currenthealth;
    public static int maxhealth;


    private void Awake()
    {
    }
    private void Update()
    {
        UpdateHealth();
        UpdateHealthText();
    }

    private void UpdateHealth()
    {
        PlayercurrentHealthSlider.maxValue = maxhealth;
        PlayercurrentHealthSlider.value = currenthealth;
    }

    private void UpdateHealthText()
    {
        PlayercurrentHealthTxt.text = currenthealth + "/" + maxhealth;
    }
}
