using UnityEngine;

public class BouncePlatform : Platform
{
    [Header("Bounce Options")]
    public float bouncePower;

    private Vector3 _bounceDirection = Vector3.up;

    protected override void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        // rb.AddForce(Vector3.up * bouncePower, ForceMode.Impulse);
        Bounce(rb, _bounceDirection);
    }

    protected void Bounce(Rigidbody rb, Vector3 direction)
    {
        rb.AddForce(direction * bouncePower, ForceMode.Impulse);
    }
}
