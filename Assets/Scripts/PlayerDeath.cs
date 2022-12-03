using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3 && other.gameObject.layer != 7 && other.gameObject.layer != 6 && other.gameObject.layer != 8)
            GameManager.Instance.Death();
    }
}
