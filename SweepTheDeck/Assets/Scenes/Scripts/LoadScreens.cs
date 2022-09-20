using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreens : MonoBehaviour {
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log(0);
    }

    public void LoadInGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log(1);
    }

    public void LoadInventory()
    {
        SceneManager.LoadScene(2);
        Debug.Log(2);
    }

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene(3);
        Debug.Log(3);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(4);
        Debug.Log(4);
    }

    public void LoadShanty()
    {
        SceneManager.LoadScene(5);
        Debug.Log(5);
    }

     
}
