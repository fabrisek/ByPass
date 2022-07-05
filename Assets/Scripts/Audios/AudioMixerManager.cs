using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    public static AudioMixerManager instance;
    [SerializeField] AudioMixer audioMixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitAudioMixerManager();
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
    void InitAudioMixerManager ()
    {
       
    }

    public void ChangeVolume (ChoseCanal canal, float value)
    {
        Debug.Log("Salut tu viens de me changer le volume frere");
        switch(canal)
        {
            case ChoseCanal.main:
                    audioMixer.SetFloat("VolumeMain", FindVolume(value));
                break;
            case ChoseCanal.music:
                    audioMixer.SetFloat("VolumeMusic", FindVolume(value));
                break;
            case ChoseCanal.sfx:
                audioMixer.SetFloat("VolumeSfx", FindVolume(value));
                break;
            case ChoseCanal.sfx3D:
                    audioMixer.SetFloat("VolumeSfx3D", FindVolume(value));
                break;
            default:
                Debug.Log("je connais pas ce canal mon pote");
                break;
        }
    }

    float FindVolume (float value)
    {
        float t = 0;
        if (value != 0)
        {
            t = value / 0.8f;
            return  Mathf.Lerp(-40, 0, t);
        }
        else
        {
            
            return  -80;
        }
    }
    // A voir avec les different etat du jeu
   // public void ChangeSnapShoot ()

    public enum ChoseCanal
    {
        main,
        music,
        sfx,
        sfx3D,
    }

   
}
