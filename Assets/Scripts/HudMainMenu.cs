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
        Instance = this;
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