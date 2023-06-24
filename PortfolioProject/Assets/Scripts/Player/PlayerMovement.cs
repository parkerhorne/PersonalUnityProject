using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerTransform;
    
    private Rigidbody _rigidbody;

    private Vector3 _direction;

    private ThirdPersonCamera _tpc;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _tpc = GameObject.Find("ThirdPersonCamera").GetComponent<ThirdPersonCamera>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        // GetDirection();
        MovePlayer();
    }

    void MovePlayer()
    {
        _direction = _tpc.GetDirectionVector();
        _rigidbody.AddForce(_direction.normalized * speed, ForceMode.Acceleration);
    }

    void GetDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = (orientation.forward * vertical + orientation.right * horizontal).normalized;

        // float vertical = Input.GetAxis("Vertical");
        // float horizontal = Input.GetAxis("Horizontal");
        // _direction = orientation.forward * vertical + orientation.right * horizontal;
        //
        // if (_direction != Vector3.zero)
        // {
        //     playerTransform.forward = Vector3.Slerp(playerTransform.forward, _direction.normalized,
        //         Time.deltaTime * rotationSpeed);
        // }
        // float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        // orientation.rotation = Quaternion.Euler(0, targetAngle, 0);
    }
}
