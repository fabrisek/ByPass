using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    //[SerializeField] HudControllerInGame _hud;
    [SerializeField] float _timer;
    [SerializeField] bool _timerIsLaunch;
    public float GetTimer() { return _timer; }
    public bool TimerIsLaunch() { return _timerIsLaunch; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void LaunchTimer(bool setTimer)
    {
        
        _timerIsLaunch = setTimer;
    }

  

    private void Update()
    {
        if (_timerIsLaunch)
        {
            _timer += Time.unscaledDeltaTime;
           if (HudMainMenu.Instance != null)
            {
                HudMainMenu.Instance.ChangeInfoTimer(FormatTime(_timer));
            }
        }
    }



    public static string FormatTime(float time)
    {
        int intTime = (int)time;
        int Minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00} : {1:00} : {2:000}", Minutes, seconds, fraction);
        return timeText;
    }
}
