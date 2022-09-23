using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public Toggle toggler;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        toggler.isOn = PlayerPrefs.GetInt("MUSICMUTED") == 1;
    }
    public void SetLevel(float sliderValue)
    {   
        mixer.SetFloat("BGMVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("BGMVolume", sliderValue);
    }

    public void ToggleMute()
    {
        if (!toggler.isOn)
        {
            mixer.SetFloat("BGMVolume", PlayerPrefs.GetFloat("BGMVolume"));
        } else
        {
            mixer.SetFloat("BGMVolume", 0);
        }
        PlayerPrefs.SetInt("MUSICMUTED", toggler.isOn ? 1 : 0);

    }
}
