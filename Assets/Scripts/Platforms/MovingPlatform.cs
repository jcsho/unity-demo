using UnityEngine;

public class MovingPlatform : Platform
{

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    public float timer = 2f;

    private Vector3 _currentLocation;
    private Vector3 _currentDirection;

    private void Start()
    {
        _currentLocation = endPoint.position;
        _currentDirection = _currentLocation - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();

        if (Vector3.Distance(_currentLocation, transform.position) < 0.1)
        {
            ChangeLocation();
            Countdown();
        }
    }

    private void Countdown()
    {
        if (timer >= 0.01)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0.01)
        {
            timer = 2f;
        }
    }

    // assume we are at startpoint
    private void MovePlatform()
    {
        _currentDirection = _currentLocation - transform.position;
        if (Vector3.Distance(_currentLocation, transform.position) > 0.1)
        {
            transform.position += _currentDirection.normalized * moveSpeed * Time.deltaTime;
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
}
