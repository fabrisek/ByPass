using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cinematic : MonoBehaviour
{
    public static Cinematic instance;
    [SerializeField] GameObject cutSceneToPlay;
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
        PlayCinematic(true);
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayCinematic (bool active)
    {
        cutSceneToPlay.SetActive(active);
    }

    
}
