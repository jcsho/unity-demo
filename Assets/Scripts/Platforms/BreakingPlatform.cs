using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : Platform
{
    public GameObject[] platformPieces;
    public float timer;
    public float explosionPower = 1f;
    public float explosionRadius = 5f;

    private Vector3[] _initialPlatformPositions;
    private Quaternion[] _initialPlatformRotations;
    private float _initialTimer;

    private void Start()
    {
        _initialPlatformPositions = new Vector3[platformPieces.Length];
        _initialPlatformRotations = new Quaternion[platformPieces.Length];

        for (int i = 0; i < platformPieces.Length; i++)
        {
            _initialPlatformPositions[i] = platformPieces[i].transform.localPosition;
            _initialPlatformRotations[i] = platformPieces[i].transform.localRotation;
        }

        _initialTimer = timer;
    }

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

    public float GetTimer()
    {
        return timer;
    }

    public MeshRenderer[] GetPlatformMeshes()
    {
        MeshRenderer[] result = new MeshRenderer[platformPieces.Length];
        for (int i = 0; i < platformPieces.Length; i++)
        {
            result[i] = platformPieces[i].GetComponent<MeshRenderer>();
        }
        return result;
    }

    public void ResetPlatform()
    {
        timer = _initialTimer;

        for (int i = 0; i < platformPieces.Length; i++)
        {
            Rigidbody rb = platformPieces[i].GetComponent<Rigidbody>();
            rb.isKinematic = true;
            platformPieces[i].transform.localPosition = _initialPlatformPositions[i];
            platformPieces[i].transform.localRotation = _initialPlatformRotations[i];
        }
    }
}
