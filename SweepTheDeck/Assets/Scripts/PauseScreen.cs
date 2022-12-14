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
        pauseScreenUI.SetActive(gameIsPaused);
        if(gameIsPaused == true)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        } else
        {
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
        }
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

    public void SettingsFromPause() //extends SwitchScenes so that the song resumes as it switches to a different scene
    {
        Debug.Log("clicked set");
        AudioListener.pause = false;
        LoadSettings();
    }

    public void MainMenuFromPause() //extends SwitchScenes so that the song resumes as it switches to a different scene
    {
        gameIsPaused = false;
        AudioListener.pause = false;
        LoadMainMenu();
    }
}
