using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestructor : MonoBehaviour
{

    public static AudioDestructor Instance;
    private void Awake()
    {
        if(AudioDestructor.Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   

}
