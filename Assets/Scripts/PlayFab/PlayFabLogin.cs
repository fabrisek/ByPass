using System;
using System.Text;
using PlayFab;
using PlayFab.ClientModels;
using Steamworks;
using UnityEngine;
using System.Net;
using System.Collections.Generic;
//using Newtonsoft.Json.Linq;
public class PlayFabLogin : MonoBehaviour
{
    public static PlayFabLogin Instance;
    [field: SerializeField] public string EntityId { get; private set; }
    [field: SerializeField] public string EntityType { get; private set; }
    [field: SerializeField] public string PlayfabId { get; private set; }
    enum FriendIdType { PlayFabId, Username, Email, DisplayName };

    List<FriendInfo> _friends = null;

    const string _apiKey = "8DC8E3A4CC23EF187598E72A1A800DBC";

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�...s�curit�...)

        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);            
        }
    }

    private void Start()
    {
        Login();        
    }        

    void GetFriends()
    {
        PlayFabClientAPI.GetFriendsList(new GetFriendsListRequest
        {
            IncludeSteamFriends = true,
            IncludeFacebookFriends = false,
            XboxToken = null
        }, result => {
            _friends = result.Friends;
            foreach (var item in _friends)
            {
                Debug.Log(item.FriendPlayFabId);
                //AddFriend(FriendIdType.PlayFabId, item.FriendPlayFabId);
            }
        }, OnError);
    }

    

    void AddFriend(FriendIdType idType, string friendId)
    {
        var request = new AddFriendRequest();
        switch (idType)
        {
            case FriendIdType.PlayFabId:
                request.FriendPlayFabId = friendId;
                break;
            case FriendIdType.Username:
                request.FriendUsername = friendId;
                break;
            case FriendIdType.Email:
                request.FriendEmail = friendId;
                break;
            case FriendIdType.DisplayName:
                request.FriendTitleDisplayName = friendId;
                break;
        }
        // Execute request and update friends when we are done
        PlayFabClientAPI.AddFriend(request, result => {
            Debug.Log("Friend added successfully!");
        }, OnError);
    }

    /// <summary>
    /// Se 
    /// </summary>
    private void Login()
    {
        if (SteamManager.Initialized)
        {
            // Execute PlayFab API call to log in with steam ticket
            PlayFabClientAPI.LoginWithSteam(new LoginWithSteamRequest
            {
                CreateAccount = true,
                SteamTicket = GetSteamAuthTicket()
            }, OnLogin, OnError);
        }
        else
        {
            print("Steam Not Initialized");
        }
    }

    /// <summary>
    /// Une fois le login reussit change les Info InGamePlayfab
    /// </summary>
    /// <param name="result"></param>
    void OnLogin(LoginResult result)
    {
        EntityId = result.EntityToken.Entity.Id;
        EntityType = result.EntityToken.Entity.Type;
        PlayfabId =  result.PlayFabId;

        UpdatePlayerName();
        UpdateProfilePicture();
        GetComponent<PlayfabGhost>().LoadAllFiles();
    }


    /// <summary>
    /// Change le pseudo sur Playfab grace au Pseudo Steam
    /// </summary>
    private void UpdatePlayerName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = SteamFriends.GetPersonaName()
        }, result =>
        {

        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void UpdateProfilePicture()
    {
        
        //Recupere Le lien JSON via l'API de Steam
        var _steamUserID = SteamUser.GetSteamID();
        string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + _apiKey + "&steamids=" + _steamUserID;

        //Telecharge puis convertie le fichier en JSON et recherche le lien de l'image
        //var ObjectPlayer = JObject.Parse(new WebClient().DownloadString(url));
        //url = ObjectPlayer["response"]["players"][0]["avatarfull"].ToString();

        //Update Image via Playfab
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest
        {
            ImageUrl = url
        }, result =>
        {

        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    /// <summary>
    /// Recupere la AuthTicket de SteamWorks    
    /// </summary>
    /// <returns></returns>
    private string GetSteamAuthTicket()
    {
        byte[] ticketBlob = new byte[1024];
        uint ticketSize;

        // Retrieve ticket; hTicket should be a field in the class so you can use it to cancel the ticket later
        // When you pass an object, the object can be modified by the callee. This function modifies the byte array you've passed to it.
        HAuthTicket hTicket = SteamUser.GetAuthSessionTicket(ticketBlob, ticketBlob.Length, out ticketSize);

        // Resize the buffer to actual length
        Array.Resize(ref ticketBlob, (int)ticketSize);

        // Convert bytes to string
        StringBuilder sb = new StringBuilder();
        foreach (byte b in ticketBlob)
        {
            sb.AppendFormat("{0:x2}", b);
        }
        return sb.ToString();
    }
}