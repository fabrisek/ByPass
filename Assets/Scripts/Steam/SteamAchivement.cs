using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;


public class SteamAchivement : MonoBehaviour
{
    public static SteamAchivement Instance;
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
    /// Add Achivement In Player Steam Profile
    /// </summary>
    public void UnlockAchivement(string achivementName)
    {
        if (!SteamManager.Initialized) { return; }

        SteamUserStats.SetAchievement(achivementName); //Code Achivement sur STEAMWORKS
        SteamUserStats.StoreStats();
    }
}

