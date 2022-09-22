using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int sceneNumber;
    private static int previousScene;
    private int oldPreviousScene;

    void Start()
    {
        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        oldPreviousScene = previousScene;
        previousScene = sceneNumber;
    }

    public void HandleLoadPrevButtonClick()
    {
        SceneManager.LoadScene(oldPreviousScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log(0);
    }

    public void LoadInGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("1");
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(2);
        Debug.Log(3);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(3);
        Debug.Log(4);
    }

    public void LoadShanty()
    {
        SceneManager.LoadScene(4);
        Debug.Log(5);
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
