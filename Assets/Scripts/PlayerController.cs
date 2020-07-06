using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 2f;
    public float jumpPower = 2f;

    private Rigidbody _rigidbody;
    private float _playerSpeed;
    private float moveX;
    private float moveY;

    // Start is called before the first frame update
    void Start()
    {
        _playerSpeed = walkSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(Vector3.up * jumpPower);
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveX, 0f, moveY);
        _rigidbody.MovePosition(_rigidbody.position + move * _playerSpeed * Time.fixedDeltaTime);
    }

}
