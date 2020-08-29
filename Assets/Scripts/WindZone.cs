using UnityEngine;

public class WindZone : MonoBehaviour, ITimer
{

    public GameObject externTimer;

    public float windPower;
    public float timer;

    private void Start()
    {
        ITimer externalTimer = externTimer.GetComponent<ITimer>();
    }

    public float GetTimer()
    {
        return timer;
    }

    public void Countdown(float amount)
    {
        timer--;
    }

    //public float windDirection;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 windForce = new Vector3(-windPower, 0, 0);
            rb.AddForce(windForce);
        }

        if (other != null)
        {
            ITimer otherTimer = other.gameObject.GetComponent<ITimer>();
            if (otherTimer != null)
            {
                otherTimer.GetTimer();
                otherTimer.Countdown(2);
            }
        }
    }
}
