using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class PlayFabHighScore : MonoBehaviour
{
    public static PlayFabHighScore Instance;



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

    public void UpdateHighScoreCloud(string levelName, int timer)
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "sendLeaderBoard",
            FunctionParameter = new { nameLevel = levelName, timerValue = timer },
            GeneratePlayStreamEvent = true,
        }, OnCloudResult, OnError);
    }

    void OnCloudResult(ExecuteCloudScriptResult result)
    {
        HudMainMenu.Instance.ChangePosPlayerText(int.Parse(result.FunctionResult.ToString()));
    }

    public void GetTopLeaderBord(string mapName)
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = mapName,
            StartPosition = 0,
            MaxResultsCount = 50,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardTopGet, OnError);
    }

    public void GetLeaderBoardAroundPlayer(string mapName)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = mapName,
            MaxResultsCount = 50,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    public void GetFriendLeaderBoard(string mapName)
    {
        var request = new GetFriendLeaderboardRequest
        {
            StatisticName = mapName,
            MaxResultsCount = 100,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetFriendLeaderboard(request, OnLeaderboardFriend, OnError);
    }

    void OnLeaderboardFriend(GetLeaderboardResult result)
    {
        HudMainMenu.Instance.ResetLeaderBoard();
        foreach (var item in result.Leaderboard)
        {
            HudMainMenu.Instance.NewItemLeaderBoard(item.Position, item.Profile.DisplayName, item.StatValue, item.Profile.AvatarUrl, item.PlayFabId);
        }
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        HudMainMenu.Instance.ResetLeaderBoard();
        foreach (var item in result.Leaderboard)
        {
            HudMainMenu.Instance.NewItemLeaderBoard(item.Position, item.Profile.DisplayName, item.StatValue, item.Profile.AvatarUrl, item.PlayFabId);
        }
    }

    void OnLeaderboardTopGet(GetLeaderboardResult result)
    {
        HudMainMenu.Instance.ResetLeaderBoard();
        foreach (var item in result.Leaderboard)
        {
            HudMainMenu.Instance.NewItemLeaderBoard(item.Position, item.Profile.DisplayName, item.StatValue, item.Profile.AvatarUrl, item.PlayFabId);
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
}
