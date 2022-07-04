using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class PlayFabHighScore : MonoBehaviour
{
    public static PlayFabHighScore Instance;
    GameObject prefabScoreTitle;
    Transform scoreboardParent;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    /// <summary>
    /// Initialise le parent Transform du HighScore
    /// </summary>
    /// <param name="prefabScoreTiles"></param>
    /// <param name="parent"></param>
    public void InitializeHighScore(GameObject prefabScoreTiles, Transform parent)
    {
        prefabScoreTitle = prefabScoreTiles;
        scoreboardParent = parent;
    }
    void UpdateHighScoreCloud()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "sendLeaderBoard",
            FunctionParameter = new { nameLevel = "Test", timerValue = 12 },
            GeneratePlayStreamEvent = true,
        }, OnCloudResult, OnError);
    }

    void OnCloudResult(ExecuteCloudScriptResult result)
    {
        Debug.Log(result.FunctionResult);
    }

    public void GetTopLeaderBord(string mapName)
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = mapName,
            StartPosition = 0,
            MaxResultsCount = 50
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardTopGet, OnError);
    }

    public void GetLeaderBoardAroundPlayer(string mapName)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = mapName,
            MaxResultsCount = 50
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        /*foreach (Transform item in scoreboardParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(prefabScoreTitle, scoreboardParent);
            TextMeshProUGUI[] text = newGo.GetComponentsInChildren<TextMeshProUGUI>();
            text[0].text = "#" + (item.Position+1).ToString();
            text[1].text = "User : " + item.Profile.DisplayName;
            text[2].text = "Score : ";//+ Timer.FormatTime(MathF.Abs((float)item.StatValue / 1000));

            
            if (item.PlayFabId == PlayFabLogin.Instance.GetPlayFabId())
            {
                text[0].color = Color.red;
                text[1].color = Color.red;
                text[2].color = Color.red;
            }
        }*/
    }


    void OnLeaderboardTopGet(GetLeaderboardResult result)
    {
       /* foreach (Transform item in scoreboardParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(prefabScoreTitle, scoreboardParent);
            TextMeshProUGUI[] text = newGo.GetComponentsInChildren<TextMeshProUGUI>();
            text[0].text = "#" + (item.Position + 1).ToString();
            text[1].text = "User : " + item.Profile.PlayerId;
            text[2].text = "Score : ";// + Timer.FormatTime(MathF.Abs((float)item.StatValue / 1000));
            //newGo.GetComponentInChildren<HighScoreButton>().SetPlayerTitleId(item.PlayFabId);
            if (item.PlayFabId == PlayFabLogin.Instance.GetPlayFabId())
            {
                text[0].color = Color.red;
                text[1].color = Color.red;
                text[2].color = Color.red;
            }    
        }*/
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
