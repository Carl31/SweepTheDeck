using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    /*INDEX
     * 0 = starting screen
     * 1 = battle
     * 2 = shanty
     * 3 = settings
     * 4 = leaderboard (DOESNT EXIST YET)
     */

    public const string PREV_PREV_SCENE = "prevPrevScene"; //dumb but we need this to get to the scene we came from when we use the back button
    public const string PREV_SCENE = "prevScene"; //technically this IS the current scene
    public const string CURRENT_SCENE = "currentScene"; //this would be next_scene in terms of order

    private void Awake()
    {
        int prevScene = SceneManager.GetActiveScene().buildIndex;
        SetPrevScene(prevScene);
    }
    public void BackButton() //for settings + shanty
    {
        int returnSceneIndex = PlayerPrefs.GetInt(PREV_PREV_SCENE, 0);
        SetCurrentScene(returnSceneIndex);
        SceneManager.LoadScene(returnSceneIndex);
    }

    public void LoadMainMenu()
    {
        SetCurrentScene(0); //SceneManager.GetSceneByName("StartingScreen").buildIndex;
        SceneManager.LoadScene("StartingScreen");
        Debug.Log("StartingScreen");
    }

    public void LoadInGame()
    {
        SetCurrentScene(1); //SceneManager.GetSceneByName("Battle").buildIndex;
        SceneManager.LoadScene("Battle");
        Debug.Log("Battle");
    }

    public void LoadShanty()
    {
        SetCurrentScene(2); //SceneManager.GetSceneByName("Shanty").buildIndex;
        SceneManager.LoadScene("Shanty");
        Debug.Log("Shanty");
    }

    public void LoadSettings()
    {
        SetCurrentScene(3); //SceneManager.GetSceneByName("Settings").buildIndex;
        SceneManager.LoadScene("Settings");
        Debug.Log("Settings");
    }

    public void LoadLeaderboard()
    {
        //SetPrevScene(SceneManager.GetActiveScene().buildIndex);
        //SetCurrentScene(4); //SceneManager.GetSceneByName("Leaderboard").buildIndex;
        Debug.Log("LoadLeaderboard Clicked");
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

    public void SetCurrentScene(int currentScene)
    {
        PlayerPrefs.SetInt(CURRENT_SCENE, currentScene);
        PlayerPrefs.Save();
    }
    public void SetPrevScene(int prevScene)
    {
        PlayerPrefs.SetInt(PREV_SCENE, prevScene);
        PlayerPrefs.Save();
    }

    public void SetPrevPrevScene(int prev2Scene)
    {
        PlayerPrefs.SetInt(PREV_PREV_SCENE, prev2Scene);
    }
}
