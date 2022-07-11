using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float amortissement;

    Vector3 dir;

    void Start()
    {
        dir = transform.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null && other.gameObject.layer == 6)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            Vector3 velocity = rb.velocity;

            //addVelocity
            velocity += dir * force * Time.deltaTime;
            velocity -= velocity * amortissement * Time.deltaTime;

            //apply velocity
            rb.velocity = velocity;
        }
    }
    //FeedBack
    void OnTriggerEnter(Collider other)
    {
       
    }
}
