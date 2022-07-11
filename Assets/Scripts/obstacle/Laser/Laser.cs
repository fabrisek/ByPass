using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject viewGamobject;
    [SerializeField] float maxScale;
    [SerializeField] LayerMask layer;
    Transform transformViewGameObject;

    float maxScaleLaser;
    float scaleLaser;
    // Start is called before the first frame update
    void Start()
    {
        InitLaser();
    }

    // Update is called once per frame
    void Update()
    {
        maxScaleLaser = CheckMaxScaleLaser();
        Debug.Log(maxScaleLaser);
        AddToMax(2);
        CheckScaleLaser();
        SetViewScale();

    }

    void InitLaser ()
    {
        transformViewGameObject = viewGamobject.transform;
        scaleLaser = maxScale;
    }

    public void AddToScaleLaser (float value)
    {
        scaleLaser += value;
    }

    void SetViewScale ()
    {
        transformViewGameObject.localScale = new Vector3(transformViewGameObject.localScale.x, transformViewGameObject.localScale.y, scaleLaser/2);
    }

    float CheckMaxScaleLaser ()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, maxScale, layer);
        if (hits.Length > 0)
        {
            Debug.Log(hits[0].transform.gameObject.name);
            return (Vector3.Distance(transform.position, hits[0].point));
        }
        else
        {

            return maxScale;
        }
    }

    void CheckScaleLaser ()
    {
        if(scaleLaser > maxScaleLaser)
        {
            scaleLaser = maxScaleLaser;
        }
        else if(scaleLaser < 0)
        {
            scaleLaser = 0;
        }

    }


    void AddToMax (float speed)
    {
        if(scaleLaser != maxScaleLaser)
        {
            AddToScaleLaser(Time.deltaTime * speed);
        }
    }
}
