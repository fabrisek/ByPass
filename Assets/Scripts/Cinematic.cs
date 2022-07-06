using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematic : MonoBehaviour
{
    public static Cinematic instance;
    [SerializeField] GameObject cutSceneToPlay;
    [SerializeField] GameObject cameras;

    bool active;
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
    // Start is called before the first frame update
    void Start()
    {
        
       // PlayCinematic(true);
     
    }

    // Update is called once per frame
    void Update()
    {
       if(active)
        {
            if (cutSceneToPlay.GetComponent<PlayableDirector>().state == PlayState.Paused)
            {
                PlayCinematic(false);
            }
                
        }
    }

    public void PlayCinematic (bool active)
    {
        this.active = active;
        cameras.SetActive(active);
       
        cutSceneToPlay.SetActive(active);
        if(!active)
        {
            GameManager.Instance.CinematicIsFinish();
        }
    }

    

    
}
