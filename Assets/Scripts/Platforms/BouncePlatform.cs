using UnityEngine;

public class BouncePlatform : Platform
{
    public float bouncePower;

    protected override void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * bouncePower, ForceMode.Impulse);
    }
}
