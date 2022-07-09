using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeController : MonoBehaviour
{
    public static FantomeController instance;


    [SerializeField] float timeBetweenSave;
    [SerializeField] Transform playerRef;
    [SerializeField] GameObject objectView;

    [SerializeField] FantomeSave fantomeToSave;
    [SerializeField] FantomeSave fantomeSaved;

    SaveState saveState;
    ReproduceState reproduceState;

    int indexOfPath;
    float duration;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            InitFantomeController();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //ReproducePath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(reproduceState != ReproduceState.finishReproduce)
        {
            ReproducePath();
        }
    }

    //==============================================================Save=======================================================================================================

    public void StartSaveFantome ()
    {
        saveState = SaveState.inSave;
       
        SaveDataInFantomeSave();
        StartCoroutine(CoroutineSaveTransformeTime());
    }

    public FantomeSave StopSaveFantome()
    {
       
        saveState = SaveState.saveFinish;
        SaveDataInFantomeSave();
        return fantomeToSave;
    }

    void InitFantomeController ()
    {
        fantomeToSave = new FantomeSave();
        saveState = SaveState.nothing;
        reproduceState = ReproduceState.nothing;
        if (timeBetweenSave == 0)
        {
            timeBetweenSave = 0.2f;
        }
    }

    IEnumerator CoroutineSaveTransformeTime()
    {
        do
        {
            SaveDataInFantomeSave();
            yield return new WaitForSeconds(timeBetweenSave);
            
        }
        while (saveState != SaveState.saveFinish);
    }

    void SaveDataInFantomeSave ()
    {
        fantomeToSave.SaveData(playerRef.position, playerRef.rotation, GameManager.Instance.ReturnTimer());
        // ajouter les valeur temps transforme etc;
    }


    //========================================================Reproduce================================================================================================================
    public void StartReproduce (FantomeSave fantomeToReproduce)
    {
        fantomeSaved = fantomeToReproduce;
        reproduceState = ReproduceState.inreproduce;
    }

    public void StopReproduce()
    {
        reproduceState = ReproduceState.finishReproduce;
    }

    void ReproducePath ()
    {


        if (indexOfPath < fantomeSaved.positionPlayer.Count && indexOfPath + 1 < fantomeSaved.positionPlayer.Count)
        { 


            if (fantomeSaved.time[indexOfPath + 1] <= GameManager.Instance.ReturnTimer())
            {

                    indexOfPath++;
                    
                    if (indexOfPath + 1 < fantomeSaved.positionPlayer.Count)
                    {
                    duration = fantomeSaved.time[indexOfPath + 1] - fantomeSaved.time[indexOfPath];
                    }
                    else
                    {
                        if (indexOfPath + 1 >= fantomeSaved.positionPlayer.Count)
                        {
                        // Debug.Log("Je suis arriver a :" + Timer.Instance.GetTimer());

                              StopReproduce();


                        }
                    }
            }
            if (indexOfPath + 1 < fantomeSaved.positionPlayer.Count)
            {
                    
                    float timePass = GameManager.Instance.ReturnTimer() - fantomeSaved.time[indexOfPath];
                    if (timePass < 0)
                    {
                        timePass = 0;
                    }
                   
                    float lerpPercent = timePass / duration;


                //objectView.transform.position = Vector3.MoveTowards(fantomeToSave.positionPlayer[indexOfPath], fantomeToSave.positionPlayer[indexOfPath + 1], duration * Time.deltaTime); 
                  objectView.transform.position = Vector3.Lerp(fantomeSaved.positionPlayer[indexOfPath], fantomeSaved.positionPlayer[indexOfPath + 1], lerpPercent);
            }
            
        }



        /*   distance = Vector3.Distance(path.pathObjList[currentWayPointID].position, transform.position);
           transform.position = Vector3.MoveTowards(transform.position, path.pathObjList[currentWayPointID].position, speed * Time.deltaTime);*/

        //ROTATION OF ENEMY
        /*  var direction = path.pathObjList[currentWayPointID].position - transform.position;

          if (direction != Vector3.zero)
          {
              direction.y = 0;
              direction = direction.normalized;
              var rotation = Quaternion.LookRotation(direction);
              transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
          }*/
    }

    public enum SaveState
    {
        inSave,
        saveFinish,
        nothing,
    }

    public enum ReproduceState
    {
        inreproduce,
        finishReproduce,
        nothing,
    }

}
