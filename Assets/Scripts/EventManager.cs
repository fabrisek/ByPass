using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static event Action<AdioManager.TypeOfSound,int,Vector3,float> PlaySound;
    public static event Action<AudioMixerManager.ChoseCanal, float> ChangeVolumeMixer;
   
}
