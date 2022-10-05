using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource eatSource;
    [SerializeField] List<AudioClip> eatClips = new List<AudioClip>();

    public const string MUSIC_KEY = "musicVolume";
    public const string SOUND_KEY = "soundVolume";


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    public void AttackSFX()
    {
        AudioClip clip = eatClips[Random.Range(0, eatClips.Count)];

        eatSource.PlayOneShot(clip);
    }

    void LoadVolume() //volume saved in VolumeSettings.cs
    {
        float music = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sound = PlayerPrefs.GetFloat(SOUND_KEY, 1f);
        int musicMute = PlayerPrefs.GetInt(VolumeSettings.MUSIC_MUTE, 0);
        int soundMute = PlayerPrefs.GetInt(VolumeSettings.SOUND_MUTE, 0);
        if(musicMute == 1)
        {
            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(0.0001f) * 20);
        } else if(musicMute == 0)
        {
            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(music) * 20);
        }

        if (soundMute == 1)
        {
            mixer.SetFloat(VolumeSettings.MIXER_SOUND, Mathf.Log10(0.0001f) * 20);
        }
        else if (soundMute == 0)
        {
            mixer.SetFloat(VolumeSettings.MIXER_SOUND, Mathf.Log10(sound) * 20);
        }
    }
}
