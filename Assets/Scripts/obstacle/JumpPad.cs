using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float force;

    [SerializeField] LayerMask playerLayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
           //Mettre effet et son
        }

        if (other.GetComponent<Rigidbody>() != null && other.gameObject.layer == 6)
        {
            Debug.Log("Salut");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            other.GetComponent<PlayerController>().SetCanDoubleJump(true);

            if (other.GetComponent<CompetenceRalentie>().IsRalentie())
            {
                rb.AddForce(force * transform.up * 1.5f, ForceMode.Impulse);
            }

            else
                rb.AddForce(force * transform.up, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("ce n est pas le player"+ other.gameObject.layer);
        }
    }
}
