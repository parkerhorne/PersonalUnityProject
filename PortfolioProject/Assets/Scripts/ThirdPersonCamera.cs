using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObject;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 _direction;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // The view direction of the camera
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        _direction = orientation.forward * vertical + orientation.right * horizontal;

        // Rotation based on player movement
        if (_direction != Vector3.zero)
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, _direction.normalized,
                Time.deltaTime * rotationSpeed);
        }
    }
}
