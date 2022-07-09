using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Doozy.Runtime.UIManager.Containers;
using Doozy.Runtime.UIManager.Components;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HudMainMenu : MonoBehaviour
{
    public static HudMainMenu Instance;

    public void OpenDeathPanel(string timer)
    {
        CloseAllPanel();
        _DeathPanel.Show();
        _timerDeath.text = timer;
    }

    [Header("PANEL")]
    [SerializeField] UIContainer _mainMenu;
    [SerializeField] UIContainer _settings;
    [SerializeField] UIContainer _levelSelectionPanel;
    [SerializeField] UIContainer _worldSelectionPanel;
    [SerializeField] UIContainer _pausePanel;
    [SerializeField] UIContainer _InGamePanel;
    [SerializeField] UIContainer _DeathPanel;
    [SerializeField] UIContainer _winPanel;
    [SerializeField] UIContainer _HighScorePanel;

    [Header("LEVEL SELECTOR")]
    [SerializeField] Transform parentSelector;
    [SerializeField] GameObject CardWorldPrefab;
    [SerializeField] TextMeshProUGUI worldName;
    [SerializeField] TextMeshProUGUI starText;

    [Header("OTHERS")]
    [SerializeField] EventSystem eventSystem;
    [SerializeField] TextMeshProUGUI _countdown;
    [SerializeField] TextMeshProUGUI _timerText;

    [SerializeField] TextMeshProUGUI _timerDeath;

    [Header("WinPanel")]
    [SerializeField] TextMeshProUGUI _posPlayer;
    [SerializeField] TextMeshProUGUI _timerWin;
    [SerializeField] TextMeshProUGUI _highScore;
    [SerializeField] Image[] allStar;
    [SerializeField] Sprite starUnlock;
    [SerializeField] Sprite startLock;
    [SerializeField] GameObject buttonNextLevel;

    [Header("Leaderboard")]
    [SerializeField] GameObject prefabScoreTitle;
    [SerializeField] Transform scoreboardParent;

    public void Win(float timer, float bestTime, SceneObject sceneObj, bool ShowNextButton)
    {
        CloseAllPanel();
        _timerWin.text = Timer.FormatTime(timer);
        _winPanel.Show();
        buttonNextLevel.SetActive(ShowNextButton);
        _highScore.text = "BEST TIME : " + Timer.FormatTime(bestTime);
        if (bestTime == 0)
        {
            _highScore.text = "BEST TIME : " + Timer.FormatTime(timer);
            _highScore.color = Color.white;
        }
        if (timer == bestTime)
        {
            _highScore.text = "NEW RECORD : " + Timer.FormatTime(bestTime);
            _highScore.color = Color.red;
        }

        if (DataManager.Instance != null)
        {
            DATA data = DataManager.Instance.Data;

            for (int i = 0; i < sceneObj.TimeStar.Length; i++)
            {
                if (bestTime <= sceneObj.TimeStar[i])
                {
                    allStar[i].sprite = starUnlock;
                }
                else
                {
                    allStar[i].sprite = startLock;
                }
            }
        }
    }

    public void ResetLeaderBoard()
    {
        foreach (Transform item in scoreboardParent)
        {
            Destroy(item.gameObject);
        }
    }

    public void NewItemLeaderBoard(int pos, string displayName, int score, string profile, string playfabId)
    {
        GameObject newGo = Instantiate(prefabScoreTitle, scoreboardParent);
        TextMeshProUGUI[] text = newGo.GetComponentsInChildren<TextMeshProUGUI>();
        text[0].text = "#" + (pos + 1).ToString();
        text[1].text = "User : " + displayName;
        text[2].text = "Score : " + Timer.FormatTime(MathF.Abs((float)score / 1000));
        newGo.GetComponent<HighScorePanel>().ChangeProfilePicture(profile, playfabId);

        if (playfabId == PlayFabLogin.Instance.PlayfabId)
        {
            text[0].color = Color.red;
            text[1].color = Color.red;
            text[2].color = Color.red;
        }
    }

    public void ChangePosPlayerText(int pos)
    {
        _posPlayer.text = "TOP #" + (pos + 1).ToString();
    }
    public StateMainMenu State { get; set; }

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

    public void ChangeInfoTimer(string timer)
    {
        _timerText.text = timer;
    }
    public void ResetTextTimer()
    {
        _timerText.text = Timer.FormatTime(0);
    }
    public void CountDown(string text, bool setActive)
    {
        
        _countdown.gameObject.SetActive(setActive);
        _countdown.text = text;

    }
    public void CloseAllPanel()
    {
        _mainMenu.Hide();
        _settings.Hide();
        _levelSelectionPanel.Hide();
        _worldSelectionPanel.Hide();
        _pausePanel.Hide();
        _InGamePanel.Hide();
        _DeathPanel.Hide();
        _winPanel.Hide();
        _HighScorePanel.Hide();
    }

    public void OpenPausePanel()
    {
        CloseAllPanel();
        _pausePanel.Show();
    }

    public void OpenGamePanel()
    {
        CloseAllPanel();
        _InGamePanel.Show();
    }

    public void OpenMainMenuPanel()
    {
        CloseAllPanel();
        _mainMenu.Show();
    }
    public void OpenPanelSelectionLevel(int worldIndex)
    {
        worldName.text = DataManager.Instance.Data.WorldData[worldIndex].WorldName;

        int totalStar = 0;
        int starUnlock = 0;


        foreach (var item in parentSelector.GetComponentsInChildren<CardWorld>())
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < DataManager.Instance.Data.WorldData[worldIndex].MapData.Count; i++)
        {
            GameObject cardObj = Instantiate(CardWorldPrefab, parentSelector);
            int starLevel = 0;
            MapData mapData = DataManager.Instance.Data.WorldData[worldIndex].MapData[i];
            for (int j = 0; j < mapData.SceneData.TimeStar.Length; j++)
            {
                totalStar++;
                if (mapData.HighScore <= mapData.SceneData.TimeStar[j] && mapData.HighScore != 0)
                {
                    starLevel++;
                    starUnlock++;
                }
            }

            if (i == 0)
            {
                eventSystem.SetSelectedGameObject(cardObj.GetComponent<UIButton>().gameObject);
            }

            cardObj.GetComponent<CardWorld>().ChangeInformation(mapData.SceneData, mapData.HighScore, totalStar, mapData.HaveUnlockLevel, i);
        }

        starText.text = "STAR : " + starUnlock.ToString() + " / " + totalStar.ToString();
    }


    public void Back()
    {
        switch (State)
        {
            case StateMainMenu.WorldSelector:
                _worldSelectionPanel.Hide();
                _mainMenu.Show();
                break;

            case StateMainMenu.LevelSelector:
                _levelSelectionPanel.Hide();
                _worldSelectionPanel.Show();
                break;

            case StateMainMenu.MenuSettings:

                break;

            case StateMainMenu.Settings:

                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySoundbutton (int son)
    {
        GameManager.Instance.PlaySound(TypeOfSound.sfx3D, Vector3.zero, (SfxSon)son);
    }
}

public enum StateMainMenu
{
    MainMenu,
    WorldSelector,
    MenuSettings,
    LevelSelector,
    Settings
}