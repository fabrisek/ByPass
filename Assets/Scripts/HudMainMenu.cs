using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Doozy.Runtime.UIManager.Containers;
using Doozy.Runtime.UIManager.Components;
public enum StateMainMenu
{
    Menu,
    Settings,
    InPanelSettings,
    InGame,
    InPanelGame
}
public class HudMainMenu : MonoBehaviour
{
    public static HudMainMenu Instance;

    [SerializeField] UIContainer _mainMenu;
    [SerializeField] UIContainer _settings;
    [SerializeField] UIContainer _levelSelectionPanel;
    [SerializeField] UIContainer _worldSelectionPanel;

    [SerializeField] GameObject panelSelector;
    [SerializeField] Transform parentSelector;
    [SerializeField] GameObject CardWorldPrefab;
    [SerializeField] TextMeshProUGUI worldName;
    [SerializeField] TextMeshProUGUI starText;

    [SerializeField] EventSystem eventSystem;

    public StateMainMenu State { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    public void OpenMainMenu()
    {
        State = StateMainMenu.Menu;
        _mainMenu.Show();
    }

    public void ClickPlay()
    {
        State = StateMainMenu.InGame;
    }

    public void OpenPanelSelectionLevel(int worldIndex)
    {
        State = StateMainMenu.InPanelGame;
        worldName.text = DataManager.Instance.Data.WorldData[worldIndex].WorldName;

        int totalStar = 0;
        int starUnlock = 0;


        foreach (var item in panelSelector.GetComponentsInChildren<CardWorld>())
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

            cardObj.GetComponent<CardWorld>().ChangeInformation(mapData.SceneData.SpriteCard, mapData.HighScore, mapData.SceneData.MapName, (i + 1).ToString(), starLevel, mapData.SceneData.IndexScene, mapData.HaveUnlockLevel);
        }

        starText.text = "STAR : " + starUnlock.ToString() + " / " + totalStar.ToString();
    }

    public void ClosePanelSettings()
    {
        HUD_Settings.Instance.CloseSettings();
        State = StateMainMenu.Settings;
    }

    public void Back()
    {
            switch (State)
            {
                case StateMainMenu.InPanelGame:
                    _levelSelectionPanel.Hide();
                    _worldSelectionPanel.Show();
                    State = StateMainMenu.InGame;
                    break;
                case StateMainMenu.InGame:
                    _worldSelectionPanel.Hide();
                    OpenMainMenu();
                    break;
                case StateMainMenu.Settings:
                    CloseSettings();
                    break;
                case StateMainMenu.InPanelSettings:
                    ClosePanelSettings();
                    break;            
        }
    }

    public void CloseSettings()
    { 
        _settings.Hide();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
