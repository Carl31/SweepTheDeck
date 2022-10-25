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
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundToggle;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SOUND = "SoundVolume";
    public const string MUSIC_MUTE = "MusicMuted";
    public const string SOUND_MUTE = "SoundMuted";

    private float min = 0.0001f;

    void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        soundSlider.onValueChanged.AddListener(SetSoundVolume);
        musicToggle.onValueChanged.AddListener(SetMusicToggle);
        soundToggle.onValueChanged.AddListener(SetSoundToggle);
    }

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY);
        soundSlider.value = PlayerPrefs.GetFloat(AudioManager.SOUND_KEY);
        musicToggle.isOn = PlayerPrefs.GetInt(MUSIC_MUTE) == 1 ? true : false; //0 = unmuted 1 = muted; which means default is false as in unmuted
        soundToggle.isOn = PlayerPrefs.GetInt(SOUND_MUTE) == 1 ? true : false; //0 = unmuted 1 = muted; which means default is false as in unmuted
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SOUND_KEY, soundSlider.value);
        PlayerPrefs.SetInt(MUSIC_MUTE, musicToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt(SOUND_MUTE, soundToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    void SetSoundVolume(float value)
    {
        audioMixer.SetFloat(MIXER_SOUND, Mathf.Log10(value) * 20);
    }

    void SetMusicToggle(bool isMuted)
    {
        musicToggle.isOn = isMuted;
        if (isMuted)
        {
            SetMusicVolume(min);
            musicSlider.interactable = false;
        }
        else
        {
            SetMusicVolume(musicSlider.value);
            musicSlider.interactable = true;
        }
    }

    void SetSoundToggle(bool isMuted)
    {
        soundToggle.isOn = isMuted;
        if (isMuted)
        {
            SetSoundVolume(min);
            soundSlider.interactable = false;
        }
        else
        {
            SetSoundVolume(soundSlider.value);
            soundSlider.interactable = true;
        }
    }
}
