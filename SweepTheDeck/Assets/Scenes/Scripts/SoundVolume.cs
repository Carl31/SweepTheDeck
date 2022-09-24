using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    public Slider slider;
    private float sliderValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("SFXVolume", sliderValue);
        //mixer.SetFloat("SFXVolume", Mathf.Log10(slider.value) * 20);
    }
    public void SetLevel(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
        //mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
    }
}
