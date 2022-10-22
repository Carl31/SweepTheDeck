using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : SwitchScene
{
    public static bool gameIsPaused = false;
    public GameObject pauseScreenUI;

    private void Start()
    {
        pauseScreenUI.SetActive(false);
    }

    public void Resume()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
        gameIsPaused = true;
    }
    public void Restart()
    {
        //not my problem lmfao
    }

    public void SettingsFromPause()
    {
        if(PlayerPrefs.HasKey(PREV_PREV_SCENE))
        {
            PlayerPrefs.SetInt(PREV_PREV_SCENE, SceneManager.GetActiveScene().buildIndex);
        }
        AudioListener.pause = false;
        LoadSettings();
    }

    public void MainMenuFromPause()
    {
        if (PlayerPrefs.HasKey(PREV_PREV_SCENE))
        {
            PlayerPrefs.SetInt(PREV_PREV_SCENE, SceneManager.GetActiveScene().buildIndex);
        }
        AudioListener.pause = false;
        LoadMainMenu();
    }
}
