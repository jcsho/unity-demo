using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    protected virtual void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name + " has landed on " + gameObject.name);
    }
}
