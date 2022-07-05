using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    [SerializeField] GameObject cutSceneToPlay;
    private void Awake()
    {
        EventManager.LauchCinematic += PlayCinematic;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
