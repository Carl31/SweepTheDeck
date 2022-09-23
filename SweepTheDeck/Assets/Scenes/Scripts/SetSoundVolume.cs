using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetSoundVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public Toggle toggler;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        toggler.isOn = PlayerPrefs.GetInt("SOUNDMUTED") == 1;
    }
    public void SetLevel(float sliderValue)
    {   
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    public void ToggleMute()
    {
        if (!toggler.isOn)
        {
            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        } else
        {
            mixer.SetFloat("SFXVolume", 0);
        }
        PlayerPrefs.SetInt("SOUNDMUTED", toggler.isOn ? 1 : 0);

    }
}
