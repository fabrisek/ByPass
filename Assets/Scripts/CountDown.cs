using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public static CountDown instance;
    [SerializeField] float timeOfCountDown;
    [SerializeField] string[] writeinCountDown;

    int count;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            InitCountDoawn();
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

    void InitCountDoawn()
    {
        
    }

    public void StartCountDown ()
    {
        count = 0;
       // Debug.Log(writeinCountDown[count]);
        count++;
        StartCoroutine(CoroutineCountDown());

    }


    IEnumerator CoroutineCountDown ()
    {
        Debug.Log(writeinCountDown[count]);
        yield return new WaitForSeconds(timeOfCountDown / writeinCountDown.Length);
        HudMainMenu.Instance.CountDown(writeinCountDown[count], true);
        count++;
        if(count < writeinCountDown.Length)
        {
            StartCoroutine(CoroutineCountDown());
        }
        else
        {
            HudMainMenu.Instance.CountDown("0", false);
            Debug.Log("CountDownEstFinie");
            GameManager.Instance.CountDownIsFinish();
        }
    }
}
