using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager 
{
    public static event Action<AudioManager.TypeOfSound,int,Vector3,float> PlaySound;
    public static event Action<AudioMixerManager.ChoseCanal, float> ChangeVolumeMixer;
    public static event Action<bool> LauchTimer;

    public static void PlaySoundEvent(AudioManager.TypeOfSound typeSound, int indexSound, Vector3 position, float volume = 1)
    {
        PlaySound.Invoke(typeSound, indexSound, position, volume);
    }

    public static void LauchTimerEvent(bool setTimer)
    {
        LauchTimer.Invoke(setTimer);
    }
}
