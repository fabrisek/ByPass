using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeController : MonoBehaviour
{

    [SerializeField] float timeBetweenSave;
    [SerializeField] Transform playerRef;

    FantomeSave fantomeToSave;
    FantomeSave fantomeSaved;

    SaveState saveState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //==============================================================Save=======================================================================================================

    public void StartSaveFantome ()
    {
        saveState = SaveState.inSave;
        SaveDataInFantomeSave();
        StartCoroutine(CoroutineSaveTransformeTime());
    }

    public void StopSaveFantome()
    {
        saveState = SaveState.saveFinish;
        SaveDataInFantomeSave();
    }

    void InitFantomeController ()
    {
        fantomeToSave = new FantomeSave();
        saveState = SaveState.nothing;
        if(timeBetweenSave == 0)
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
        while (saveState == SaveState.saveFinish);
    }

    void SaveDataInFantomeSave ()
    {
        fantomeToSave.SaveData(playerRef.position, playerRef.rotation, GameManager.Instance.ReturnTimer());
        // ajouter les valeur temps transforme etc;
    }


    //========================================================Reproduce================================================================================================================

    void ReproducePath ()
    {






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

}
