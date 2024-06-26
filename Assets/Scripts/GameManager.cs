using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    StateGame stateOfGame;
    public int WorldIndex { get; set; }
    public int LevelIndex { get; set; }

    public void ChangeWorldIndex(int index) { WorldIndex = index; }
    public void ChangeLevelIndex(int index) { LevelIndex = index; }

    SceneObject lastSceneObj;
    internal void Death()
    {
        if (stateOfGame != StateGame.inWin && stateOfGame != StateGame.inDead)
        {
            Time.timeScale = 0;
            Timer.instance.LaunchTimer(false);
            HudMainMenu.Instance.OpenDeathPanel(Timer.FormatTime(Timer.instance.GetTimer()));
            stateOfGame = StateGame.inDead;
            Cursor.lockState = CursorLockMode.None;
            ChangeActionMap(stateOfGame);
            Cursor.visible = true;
        }
    }

    public void GetLeaderBoardAroundPlayer()
    {
        PlayFabHighScore.Instance.GetLeaderBoardAroundPlayer(DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].SceneData.MapName);
    }

    public void GetTopLeaderBoard()
    {
        PlayFabHighScore.Instance.GetTopLeaderBord(DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].SceneData.MapName);
    }
    public void GetFriendLeaderBoard()
    {
        PlayFabHighScore.Instance.GetFriendLeaderBoard(DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].SceneData.MapName);
    }

    internal void Win()
    {
        if (stateOfGame != StateGame.inWin && stateOfGame != StateGame.inDead)
        {
            Timer.instance.LaunchTimer(false);
            FantomeController.instance.StopSaveFantome(); // recuperer ici la save du fantome
            FantomeController.instance.StopReproduce();
            Cursor.lockState = CursorLockMode.None;
            stateOfGame = StateGame.inWin;
            ChangeActionMap(stateOfGame);
            Cursor.visible = true;
            DataManager.Instance.SetRecord(Timer.instance.GetTimer(), LevelIndex, WorldIndex, FantomeController.instance.StopSaveFantome());
            HudMainMenu.Instance.Win(
                    Timer.instance.GetTimer(),
                    DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].HighScore,
                    DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].SceneData,
                    ShowNextButton()
                ); ;
        }
    }

    public void NextLevel()
    {

    }

    private bool ShowNextButton()
    {
        DATA data = DataManager.Instance.Data;

        if (data.WorldData[WorldIndex].MapData.Count - 1 == LevelIndex)
        {
            if (WorldIndex + 1 < data.WorldData.Count)
            {
                if (data.WorldData[WorldIndex + 1].MapData[0] != null)
                {
                    return true;
                }
            }
            else
                return false;
        }

        else
        {
            return true;
        }
        return false;
    }

    //  [SerializeField] Input inputActions;

    public StateGame StateOfGame
    {
        get
        {
            return stateOfGame;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            InitGameManager();
            UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        }
        else
        {
            InputManager.Instance.ActiveActioMapInGame(true);
            Destroy(gameObject);
        }
    }

    void InitGameManager ()
    {
        stateOfGame = StateGame.inMainMenu;
        ChangeActionMap(stateOfGame);
        InputManager.Instance.ActiveActioMapInGame(true);
    }

    public void PlaySound(TypeOfSound typeSound, Vector3 position, SfxSon sonSfx = SfxSon.onButton, float volume = 1, MusicSon sonMusic = MusicSon.musicMainMenu)
    {
        AudioManager.instance.PlaySound(typeSound, position, volume, sonSfx,sonMusic);
    }

    public void ChangeVolumeMixer(AudioMixerManager.ChoseCanal trypePiste, float volume)
    {
        AudioMixerManager.instance.ChangeVolume(trypePiste, volume);
    }

    public void LoadLevel (SceneObject obj)
    {
        LevelLoader.Instance.StartLoadScene(obj);
        HudMainMenu.Instance.CloseAllPanel();
        stateOfGame = StateGame.inGame;
    }

    public void FinishLoadLevel (SceneObject obj)
    {
        if (obj.IndexScene != 0)
        {
            if (lastSceneObj != null && obj == lastSceneObj)
            {
                HudMainMenu.Instance.ResetTextTimer();
                StartCountDown();
            }
            else
            {
                lastSceneObj = obj;
                LauchCinematic(true);
            }
        }
    }

    public void LauchCinematic(bool active)
    {
        HudMainMenu.Instance.ResetTextTimer();
        stateOfGame = StateGame.inCinematic;
        Cinematic.instance.PlayCinematic(active);
        ChangeActionMap(stateOfGame);
    }

    public void CinematicIsFinish ()
    {
       
        StartCountDown();
       
    }

    public void StartCountDown()
    {
        stateOfGame = StateGame.inCountDown;
        HudMainMenu.Instance.OpenGamePanel();
        CountDown.instance.StartCountDown();
       // ChangeActionMap(stateOfGame);
    }

    public void CountDownIsFinish()
    {
        StartLevel();
    }


    public void Back()
    {
        Debug.Log("Back");
        HudMainMenu hud = HudMainMenu.Instance;
        switch (stateOfGame)
        {
            case StateGame.inGame:
                Pause();
                break;
            case StateGame.inMainMenu:

                switch (hud.State)
                {
                    case StateMenu.WorldSelector:
                        hud.OpenMainMenuPanel();
                        break;

                    case StateMenu.LevelSelector:
                        hud.OpenWorldSelector();
                        break;

                    case StateMenu.MenuSettings:
                        hud.OpenMainMenuPanel();
                        break;

                    case StateMenu.Settings:
                        hud.OpenSettingMenu();
                        break;
                }

                break;
            case StateGame.inPause:

                switch (hud.State)
                {
                    case StateMenu.Pause:
                        Pause();
                        break;

                    case StateMenu.MenuSettings:
                        hud.OpenPausePanel();
                        break;

                    case StateMenu.Settings:
                        hud.OpenSettingMenu();
                        break;

                    case StateMenu.Leaderboard:
                        hud.OpenPausePanel();
                        break;
                }
                break;

            case StateGame.inCinematic:
                LauchCinematic(false);
                break;
        }
    }

    public void Restart()
    {
        //stateOfGame = StateGame.inCountDown;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        HudMainMenu.Instance.CloseAllPanel();
        Time.timeScale = 1;
        StartCoroutine(CoroutineCountDown());
        


    }

    public void MainMenu()
    {
        HudMainMenu.Instance.State = StateMenu.MainMenu;
        HudMainMenu.Instance.OpenMainMenuPanel();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        stateOfGame = StateGame.inMainMenu;
        Cursor.lockState = CursorLockMode.None;
        ChangeActionMap(stateOfGame);
        Cursor.visible = true;
    }

    public void Pause()
    {
        switch(stateOfGame)
        {
            case StateGame.inGame:
                HudMainMenu.Instance.State = StateMenu.InGame;
                Time.timeScale = 0;
                stateOfGame = StateGame.inPause;
                LauchTimer(false);
                ChangeActionMap(stateOfGame);
                HudMainMenu.Instance.OpenPausePanel();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                break;
            case StateGame.inPause:
                HudMainMenu.Instance.State = StateMenu.Pause;
                Time.timeScale = 1;
                stateOfGame = StateGame.inGame;
                LauchTimer(true);
                ChangeActionMap(stateOfGame);
                HudMainMenu.Instance.OpenGamePanel();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                break;

            case StateGame.inCountDown:
                Debug.Log("Tu ne peux pas mettrepause ou passer le countDown c est pour ca que j ai cree ce state");
                break;

            default:
                Debug.Log("ce State n est pas pris en compte" + stateOfGame);
                break;

        }
       /* if (stateOfGame == StateGame.inGame)
        {
            Time.timeScale = 0;
            stateOfGame = StateGame.inPause;
            LauchTimer(false);
            ChangeActionMap(stateOfGame);
            HudMainMenu.Instance.OpenPausePanel();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerCam.Instance.enabled = false;
        }
        else if(stateOfGame == StateGame.inPause)
        {
            Time.timeScale = 1;
            stateOfGame = StateGame.inGame;
            LauchTimer(true);
            ChangeActionMap(stateOfGame);
            HudMainMenu.Instance.OpenGamePanel();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerCam.Instance.enabled = true;
            InputManager.Instance.enabled = false;
            InputManager.Instance.enabled = true;
        }
        else if(stateOfGame == StateGame.inCinematic)
        {
            LauchCinematic(false);
        }*/
    }

    public void StartLevel ()
    {
        stateOfGame = StateGame.inGame;
        ChangeActionMap(stateOfGame);
        if (DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].fantome != null)
            FantomeController.instance.StartReproduce(DataManager.Instance.Data.WorldData[WorldIndex].MapData[LevelIndex].fantome, "Place Mon Psuedo Ici");
        FantomeController.instance.StartSaveFantome();
        LauchTimer(true);
        //LevelManager.instance.StartLevel();
    }

    public void LauchTimer(bool setTimer)
    {
        Timer.instance.LaunchTimer(setTimer);
    }

    public float ReturnTimer ()
    {
       return Timer.instance.GetTimer();
    }

    public void ChangeActionMap (StateGame actionMapActive)
    {
        switch(actionMapActive)
        {
            case StateGame.inGame:
                Debug.Log("je Change l'actionMap en action Map InGame");
                InputManager.Input.InGame.Enable();
                InputManager.Input.InMainMenu.Disable();
                InputManager.Instance.ActiveActioMapInGame(true);
                Debug.Log(InputManager.Input.InGame.enabled);
                Debug.Log(InputManager.Input.InMainMenu.enabled);
                PlayerController.Instance.enabled = true;
                PlayerCam.Instance.enabled = true;
                break;
            case StateGame.inMainMenu:
            case StateGame.inPause:
                Debug.Log("je Change l'actionMap en action Map Menu");
                InputManager.Input.InGame.Disable();
                InputManager.Input.InMainMenu.Enable();                
                InputManager.Instance.ActiveActioMapInGame(true);

                if (PlayerController.Instance != null)
                    PlayerController.Instance.enabled = false;

                if (PlayerCam.Instance !=null)
                    PlayerCam.Instance.enabled = false;
                break;

            case StateGame.inCinematic:
                InputManager.Input.InGame.Enable();
                InputManager.Input.InMainMenu.Disable();
                InputManager.Instance.ActiveActioMapInGame(true);
                PlayerController.Instance.enabled = false;
                PlayerCam.Instance.enabled = false;
                break;

            case StateGame.inDead:
                InputManager.Input.InGame.Enable();
                InputManager.Input.InMainMenu.Disable();
                InputManager.Instance.ActiveActioMapInGame(true);
                PlayerController.Instance.enabled = false;
                PlayerCam.Instance.enabled = false;
                break;
            case StateGame.inWin:
                InputManager.Input.InGame.Enable();
                InputManager.Input.InMainMenu.Disable();
                InputManager.Instance.ActiveActioMapInGame(true);
                PlayerController.Instance.enabled = false;
                PlayerCam.Instance.enabled = false;
                break;
            default:
                Debug.Log("le state action map en parametre n est pas bon");
                break;
        }
    }

    IEnumerator CoroutineCountDown()
    {
       
        yield return new WaitForSeconds(0.2f);
        FinishLoadLevel(lastSceneObj);
    }




    public enum ActionMapEnum
    {
        inGame,
        inMenu,
    }
}
