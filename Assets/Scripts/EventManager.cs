using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<AdioManager.TypeOfSound,int,Vector3,float> PlaySound;
    public static event Action<AudioMixerManager.ChoseCanal, float> ChangeVolumeMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
