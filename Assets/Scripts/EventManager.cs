using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class EventManager :MonoBehaviour
{
    public static event Action<AdioManager.TypeOfSound,int,Vector3,float> PlaySound;
    public static event Action<AudioMixerManager.ChoseCanal, float> ChangeVolumeMixer;
    public static event Action<bool> LauchTimer;

    public static EventManager Instance;
    private void Awake()
    {

        if (EventManager.Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        
    }

    public static void PlaySoundEvent(AdioManager.TypeOfSound typeSound, int indexSound, Vector3 position, float volume = 1)
    {
        PlaySound.Invoke(typeSound, indexSound, position, volume);
    }

    public static void LauchTimerEvent(bool setTimer)
    {
        LauchTimer.Invoke(setTimer);
    }
}
