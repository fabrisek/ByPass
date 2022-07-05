using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Doozy.Runtime.UIManager.Containers;
using Doozy.Runtime.UIManager.Components;

public class HudMainMenu : MonoBehaviour
{
    public static HudMainMenu Instance;

    [Header("PANEL")]
    [SerializeField] UIContainer _mainMenu;
    [SerializeField] UIContainer _settings;
    [SerializeField] UIContainer _levelSelectionPanel;
    [SerializeField] UIContainer _worldSelectionPanel;
    [SerializeField] UIContainer _pausePanel;
    [SerializeField] UIContainer _InGamePanel;

    [Header("LEVEL SELECTOR")]
    [SerializeField] Transform parentSelector;
    [SerializeField] GameObject CardWorldPrefab;
    [SerializeField] TextMeshProUGUI worldName;
    [SerializeField] TextMeshProUGUI starText;

    [Header("OTHERS")]
    [SerializeField] EventSystem eventSystem;

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
    public void CloseAllPanel()
    {
        _mainMenu.Hide();
        _settings.Hide();
        _levelSelectionPanel.Hide();
        _worldSelectionPanel.Hide();
        _pausePanel.Hide();
        _InGamePanel.Hide();
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

            cardObj.GetComponent<CardWorld>().ChangeInformation(mapData.SceneData, mapData.HighScore, totalStar, mapData.HaveUnlockLevel);
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
}

public enum StateMainMenu
{
    MainMenu,
    WorldSelector,
    MenuSettings,
    LevelSelector,
    Settings
}