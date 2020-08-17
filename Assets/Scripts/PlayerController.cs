using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 2f;
    public float sprintSpeed = 3f;
    public float rotateSpeed = 10f;
    public float jumpPower = 2f;
    public float groundDistance = 1f;
    public LayerMask groundLayer;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _playerSpeed;
    private float _moveX;
    private float _moveY;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerSpeed = walkSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get our key input for movement
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        _playerSpeed = walkSpeed;

        ChangeAnimation();
        Jump();
        Sprint();
    }

    private void FixedUpdate()
    {
        Vector3 rotate = new Vector3(0f, _moveX * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(rotate * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _moveY * _playerSpeed * Time.fixedDeltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _playerSpeed = sprintSpeed;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector3.up * jumpPower);
        }

        if (Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer))
        {
            Debug.DrawRay(transform.position, Vector3.down * groundDistance, Color.green);
            _isGrounded = true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * groundDistance, Color.red);
            _isGrounded = false;
        }
    }

    private void ChangeAnimation()
    {
        _animator.SetFloat("Right", _moveX);
        _animator.SetFloat("Forward", _moveY);
    }

}
