using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SOUND = "SoundVolume";

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSoundVolume);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        soundSlider.value = PlayerPrefs.GetFloat(AudioManager.SOUND_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SOUND_KEY, soundSlider.value);
        PlayerPrefs.Save();
    }

    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);
    }
    void SetSoundVolume(float value)
    {
        audioMixer.SetFloat(MIXER_SOUND, Mathf.Log10(value) * 20);
    }
}
