using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{

    public float windPower;
    //public float windDirection;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 windForce = new Vector3(-windPower, 0, 0);
            rb.AddForce(windForce);
        }
    }
}
