using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform upPosition;
    [SerializeField] Transform downPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //go up
        if (rb.velocity.y > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, upPosition.position, Time.deltaTime*speed);
        }
        //goDown
        else if(rb.velocity.y < -0.5f)
        {
            transform.position = Vector3.Lerp(transform.position,downPosition.position, Time.deltaTime*speed/5);
        }
        //wigglegun
        else
        {

        }
    }
}
