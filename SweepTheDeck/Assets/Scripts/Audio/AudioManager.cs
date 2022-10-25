using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource bgmSource; //bgm source
    [SerializeField] AudioSource sfxSource; //sfx source
    AudioClip sfxClip; //sfx clip
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
        if(source != instance.bgmSource.clip) 
        {
            //Debug.Log("doesnt match");
            bgmSource.enabled = false;
            bgmSource.clip = source;
            bgmSource.enabled = true;
        }
    }
    public void PlayButtonSFX() //general buttons
    {
        sfxClip = sfxClips[0];
        sfxSource.PlayOneShot(sfxClip);
    }

    //shanty UI
    public void PlayPurchaseSFX()
    {
        sfxClip = sfxClips[1];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayEquipSFX(bool isEquipped)
    {
        if(isEquipped)
            sfxClip = sfxClips[2];
        else
            sfxClip = sfxClips[3];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlaySelectCategorySFX()
    {
        sfxClip = sfxClips[4];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayCoin()
    {
        sfxClip = sfxClips[5];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayGunshot()
    {
        sfxClip = sfxClips[6];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayJump()
    {
        sfxClip = sfxClips[7];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayDamagePlayer()
    {
        sfxClip = sfxClips[8];
        sfxSource.PlayOneShot(sfxClip);
    }
    public void PlayPlayerDie()
    {
        sfxClip = sfxClips[9];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayWalk()
    {
        sfxClip = sfxClips[10];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayEnemySpawn()
    {
        sfxClip = sfxClips[11];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayDamageEnemy()
    {
        sfxClip = sfxClips[12];
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayWaveComplete()
    {
        sfxClip = sfxClips[13];
        sfxSource.PlayOneShot(sfxClip);
    }
    public void PlayAttack()
    {
        sfxClip = sfxClips[14];
        sfxSource.PlayOneShot(sfxClip);
    }
    public void PlayAttackEnemy()
    {
        sfxClip = sfxClips[15];
        sfxSource.PlayOneShot(sfxClip);
    }

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
