using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    StateGame stateOfGame;

    [SerializeField] Input inputActions;

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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitGameManager ()
    {
        stateOfGame = StateGame.inMainMenu;
        inputActions = new Input();
        ChangeActionMap(stateOfGame);


    }

    public void PlaySound(AudioManager.TypeOfSound typeSound, int indexSound, Vector3 position, float volume = 1)
    {
        AudioManager.instance.PlaySound(typeSound, indexSound, position, volume);
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

    public void LauchCinematic(bool active)
    {
        Cinematic.instance.PlayCinematic(active);
    }

    public void CinematicIsFinish ()
    {
        StartCountDown();
    }

    public void StartCountDown()
    {
        CountDown.instance.StartCountDown();
    }

    public void CountDownIsFinish()
    {
        StartLevel();
    }


    public void Back()
    {

    }

    public void MainMenu()
    {
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
        if (stateOfGame == StateGame.inGame)
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
        else
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
    }

    public void StartLevel ()
    {
        stateOfGame = StateGame.inGame;
        ChangeActionMap(stateOfGame);
        LauchTimer(true);
        //LevelManager.instance.StartLevel();
    }

    public void LauchTimer(bool setTimer)
    {
        Timer.instance.LaunchTimer(setTimer);
    }

    public void ChangeActionMap (StateGame actionMapActive)
    {
        switch(actionMapActive)
        {
            case StateGame.inGame:
                inputActions.InGame.Enable();
                inputActions.InMainMenu.Disable();
                break;
            case StateGame.inMainMenu:
            case StateGame.inPause:
                inputActions.InGame.Disable();
                inputActions.InMainMenu.Enable();
                break;
            default:
                Debug.Log("le state action map en parametre n est pas bon");
                break;
        }
    }

    public enum ActionMapEnum
    {
        inGame,
        inMenu,
    }
}