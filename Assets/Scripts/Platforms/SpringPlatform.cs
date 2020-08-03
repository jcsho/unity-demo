using UnityEngine;

public class SpringPlatform : BouncePlatform
{
    [Header("Spring Options")]
    public Vector3 springDirection;

    protected override void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Bounce(rb, springDirection.normalized);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(transform.position, springDirection.normalized * 2);
    }
}
