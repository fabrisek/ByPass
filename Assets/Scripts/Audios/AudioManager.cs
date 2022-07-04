using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] soundEffects, music;
    [SerializeField] AudioSource audioSourceSoundEffect, audioSourceSfx3D;
   
    [SerializeField] AudioSource[] audioSourceMusic;
    [SerializeField] float speedTransition;
    int indexMusic;
    float volumeMusic;
    EtatMusic etatmusic;
    private void Awake()
    {
        InitAudioManager();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(etatmusic == EtatMusic.musicTransition)
        {
            TransitionMusic(volumeMusic);
        }
        else if (etatmusic == EtatMusic.stopMusic)
        {
            DecresseVolumeMusic();
        }

    }

    void InitAudioManager ()
    {
        indexMusic = -1;
        etatmusic = EtatMusic.noMusic;
        EventManager.PlaySound += PlaySound;
    }

    public void PlaySound(TypeOfSound typeDeSon, int indexSound, Vector3 position, float volume = 1)
    {
        switch(typeDeSon)
        {
            case TypeOfSound.music:
                ChoseFunctionForMusic(indexSound, volume);
                break;
            case TypeOfSound.sfx:
                PlaySoundEffect(indexSound, volume);
                break;
            case TypeOfSound.sfx3D:
                PlaySoundEffect3D(indexSound, position, volume);
                break;
            case TypeOfSound.stopMusic:
                etatmusic = EtatMusic.stopMusic;
                break;
            default:
                Debug.Log("Connais pas ton type de son frere");
                break;

        }
    }

    void PlaySoundEffect(int indexSound, float volumeScale)
    { 
        audioSourceSoundEffect.PlayOneShot(soundEffects[indexSound], volumeScale);
    }

    void PlaySoundEffect3D(int index, Vector3 position, float volumeScale)
    {
        audioSourceSfx3D.gameObject.transform.position = position;
        audioSourceSfx3D.PlayOneShot(soundEffects[index], volumeScale);
    }

    void ChoseFunctionForMusic (int index, float volumeScal)
    {
        switch(etatmusic)
        {
            case EtatMusic.noMusic:
                etatmusic = EtatMusic.musicOn;
                indexMusic = 0;
                SetMusic(index, volumeScal);
                PlayMusic();
                break;
            case EtatMusic.musicOn:
                etatmusic = EtatMusic.musicTransition;
                indexMusic = CheckIndexFree();
                volumeMusic = volumeScal;
                SetMusic(index, volumeScal);
                PlayMusic();

                break;
            case EtatMusic.musicTransition:
                etatmusic = EtatMusic.musicTransition;
                indexMusic = CheckIndexFree();
                volumeMusic = volumeScal;
                SetMusic(index, volumeScal);
                PlayMusic();
                break;
            default:
                etatmusic = EtatMusic.musicOn;
                indexMusic = 0;
                SetMusic(index, volumeScal);
                PlayMusic();
                break;

        }
    }

    void SetMusic (int index, float volumeScale)
    {
        audioSourceMusic[indexMusic].clip = music[index];
        audioSourceMusic[indexMusic].volume = volumeScale;
    }

    void PlayMusic()
    {
        
        audioSourceMusic[indexMusic].Play();
    }

    int CheckIndexFree ()
    {
        switch (indexMusic)
        {
            case 1:
                return 0;
                break;
            case 0:
                return 1;
                break;
            default:
                return -1;
                break;
        }
    }
    void TransitionMusic(float volumeToGo)
    {
        if (audioSourceMusic[indexMusic].volume < volumeToGo)
        {
            audioSourceMusic[indexMusic].volume += Time.deltaTime * speedTransition;
        }
        else
        {
            audioSourceMusic[CheckIndexFree()].volume = volumeToGo;
        }
        if (audioSourceMusic[CheckIndexFree()].volume > 0)
        {
            audioSourceMusic[CheckIndexFree()].volume -= Time.deltaTime * speedTransition;
        }
        else
        {
            audioSourceMusic[CheckIndexFree()].volume = 0;
        }
        if(audioSourceMusic[indexMusic].volume >= volumeToGo && audioSourceMusic[CheckIndexFree()].volume <= 0)
        {
            etatmusic = EtatMusic.musicOn;
        }
    }
    void StopMusic()
    {

        audioSourceMusic[indexMusic].Stop();
    }

    void DecresseVolumeMusic ()
    {
        if (audioSourceMusic[indexMusic].volume > 0)
        {
            audioSourceMusic[indexMusic].volume -= Time.deltaTime * speedTransition;
        }
        else
        {
            audioSourceMusic[CheckIndexFree()].volume = 0;
            StopMusic();
            etatmusic = EtatMusic.noMusic;
            indexMusic = -1;
        }
    }

    public enum TypeOfSound
    {
        music,
        sfx,
        sfx3D,
        stopMusic,
    }

    public enum EtatMusic
    {
        noMusic,
        musicOn,
        musicTransition,
        stopMusic,
    }


}
