using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    StateGame stateOfGame;

    public StateGame StateOfGame
    {
        get
        {
            return stateOfGame;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            InitGameManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitGameManager ()
    {
        stateOfGame = StateGame.inMainMenu;
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
    }

    public static void LauchCinematic(bool active)
    {
        Cinematic.instance.PlayCinematic(active);
    }

    public void StartCountDown()
    {
        CountDown.instance.StartCountDown();
    }

    public void ChangeActionMap()
    {

    }

    public void ShowCanvas()
    {

    }

    public void StartLevel ()
    {
        ChangeActionMap();
        LevelManager.instance.StartLevel();
    }

    public void LauchTimer(bool setTimer)
    {
        Timer.instance.LaunchTimer(setTimer);
    }



}
