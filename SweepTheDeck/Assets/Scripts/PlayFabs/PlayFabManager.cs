using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    void Start()
    {
        Login();
    }
    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Success");
        if(rowPrefab != null)
        {
            GetLeaderBoard();
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("error");
    }

    public void SendLeaderboard(int score)
    {
        Debug.Log("Sending score" + score);
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate { 
                StatisticName = "HighScores",  Value = score
            }
        }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("updated lb successfully");
    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScores",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        Debug.Log("got leaderboard");
        foreach (Transform item in rowsParent)
        {
            Debug.Log("got leaderboard");
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGO = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGO.GetComponentsInChildren<TMP_Text>();
            texts[0].SetText((item.Position + 1).ToString());
            texts[1].SetText(item.PlayFabId.ToString());
            texts[2].SetText(item.StatValue.ToString());
            Debug.Log(string.Format("PLACE : {0} | ID:{1 | VALUE{2}", item.Position, item.PlayFabId, item.StatValue));
        }
    }

}
