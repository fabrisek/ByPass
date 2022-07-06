using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEffect : MonoBehaviour
{
    // Start is called before the first frame update
    float startY;
    [SerializeField] float range;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform upPosition;
    [SerializeField] Transform downPosition;
    void Start()
    {
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //go up
        if (rb.velocity.y > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, upPosition.position, Time.deltaTime*2);
        }
        //goDown
        else if(rb.velocity.y < -0.5f)
        {
            transform.position = Vector3.Lerp(transform.position,downPosition.position, Time.deltaTime*2);
        }
        //wigglegun
        else
        {
            transform.position = Vector3.Lerp(transform.position, downPosition.position, Time.deltaTime);
        }
    }
}
