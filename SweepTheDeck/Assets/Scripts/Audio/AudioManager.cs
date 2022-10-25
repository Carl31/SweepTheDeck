using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource audioSource; //bgm source
    [SerializeField] AudioSource uiAudioSource; //sfx source
    AudioClip uiAudioClip; //sfx clip
    public AudioClip[] bgmClips;
    public AudioClip[] sfxClips;

    public const string MUSIC_KEY = "musicVolume";
    public const string SOUND_KEY = "soundVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        //Debug.Log(gameObject.enemyName);
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadVolume(); 
    }
    //called whenever new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AudioClip source = null;

        switch (scene.buildIndex)
        {
            case 1:
                //Debug.Log(1);
                source = bgmClips[1];
                break;
            case 2:
                //Debug.Log(2);
                source = bgmClips[2];
                break;
            default:
                //Debug.Log("0 or 3");
                source = bgmClips[0];
                break;
        }
        if(source != instance.audioSource.clip) 
        {
            //Debug.Log("doesnt match");
            audioSource.enabled = false;
            audioSource.clip = source;
            audioSource.enabled = true;
        }
    }
    public void PlayButtonSFX() //general buttons
    {
        uiAudioClip = sfxClips[0];
        uiAudioSource.PlayOneShot(uiAudioClip);
    }

    //shanty UI
    public void PlayPurchaseSFX()
    {
        uiAudioClip = sfxClips[1];
        uiAudioSource.PlayOneShot(uiAudioClip);
    }

    public void PlayEquipSFX(bool isEquipped)
    {
        if(isEquipped)
            uiAudioClip = sfxClips[2];
        else
            uiAudioClip = sfxClips[3];
        uiAudioSource.PlayOneShot(uiAudioClip);
    }

    public void PlaySelectCategorySFX()
    {
        uiAudioClip = sfxClips[4];
        uiAudioSource.PlayOneShot(uiAudioClip);
    }

    /*LIST OF PLAYER SFX
     *WALK
     *JUMP
     *LAND AFTER JUMP
     *ATTACK- VOICE
     *ATTACK- SLASH
     *ATTACK- GUN
     *TAKE DAMAGE- VOICE
     *TAKE DAMAGE- HIT
     *DIE
     *COLLECT COINS (maybe)
     
    public void AttackSFX() //LOL
    {
        AudioClip clip = playerAudioClips[Random.Range(0, playerAudioClips.Count)];

        playerAudioSource.PlayOneShot(clip);
    }*/

    void LoadVolume() //volume saved in VolumeSettings.cs
    {
        float music = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sound = PlayerPrefs.GetFloat(SOUND_KEY, 1f);
        int musicMute = PlayerPrefs.GetInt(VolumeSettings.MUSIC_MUTE, 0);
        int soundMute = PlayerPrefs.GetInt(VolumeSettings.SOUND_MUTE, 0);
        if (musicMute == 1)
        {
            mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(0.0001f) * 20);
        }
        else if (musicMute == 0)
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
