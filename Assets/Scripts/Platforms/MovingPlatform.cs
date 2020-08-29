using UnityEngine;

public class MovingPlatform : Platform, ITimer
{

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    public float timer = 2f;

    private Vector3 _currentLocation;
    private Vector3 _currentDirection;
    private Rigidbody _rigidbody;
    private float _timerLength;

    private void Start()
    {
        _currentLocation = endPoint.position;
        _currentDirection = _currentLocation - transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        _timerLength = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(_currentLocation, transform.position) < 0.1)
        {
            ChangeLocation();
            Countdown();
        }
    }

    private void FixedUpdate()
    {
        MovePlatform();
    }

    public void Countdown()
    {
        if (timer >= 0.01)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0.01)
        {
            timer = _timerLength;
        }
    }

    // assume we are at startpoint
    private void MovePlatform()
    {
        _currentDirection = _currentLocation - transform.position;
        if (Vector3.Distance(_currentLocation, transform.position) > 0.1)
        {
            //transform.position += _currentDirection.normalized * moveSpeed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + _currentDirection.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void ChangeLocation()
    {
        if (timer <= 0.01)
        {
            if (_currentLocation == endPoint.position)
            {
                _currentLocation = startPoint.position;
            }
            else if (_currentLocation == startPoint.position)
            {
                _currentLocation = endPoint.position;
            }
        }
    }

    public float GetTimer()
    {
        return timer;
    }
}
