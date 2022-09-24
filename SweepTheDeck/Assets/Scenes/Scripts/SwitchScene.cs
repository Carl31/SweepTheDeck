using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("StartingScreen");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartingScreen");
        Debug.Log("StartingScreen");
    }

    public void LoadInGame()
    {
        SceneManager.LoadScene("Battle");
        Debug.Log("Battle");
    }

    public void LoadLeaderboard()
    {
        Debug.Log("LoadLeaderboard Clicked");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Settings");
    }

    public void LoadShanty()
    {
        SceneManager.LoadScene("Shanty");
        Debug.Log("Shanty");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }

    public void Feedback()
    {
        Application.OpenURL("https://docs.google.com/forms/d/12jqOnK9puSLrtxIkX0zqMkPwTXJD51CWmECBIveFZP8/viewform?edit_requested=true");
        Debug.Log("opening feedback");
    }

}
