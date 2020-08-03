using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : Platform
{
    public GameObject[] platformPieces;
    public float timer = 1f;
    public float explosionPower = 1f;
    public float explosionRadius = 5f;

    private void Update()
    {
        if (timer < 0.01)
        {
            BreakApart();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer -= Time.deltaTime;
        }
    }

    private void BreakApart()
    {
        for (int i = 0; i < platformPieces.Length; i++)
        {
            Rigidbody rb = platformPieces[i].GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddExplosionForce(explosionPower, transform.position, explosionRadius);
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
