using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float speed = 5.0f;
    void Start()
    {
        _player = GameObject.Find("PlayerCapsule");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FollowPlayer());
    }

    float PlayerDistance()
    {
        Debug.Log("Player Position: " + _player.transform.position);
        return Vector3.Distance(_player.transform.position, transform.position);
    }

    Vector3 VelocityDirection()
    {
        return Vector3.Normalize(_player.transform.position - transform.position);
    }
    IEnumerator FollowPlayer()
    {
        _rb.velocity = VelocityDirection() * speed;
        yield return new WaitForSeconds(.25f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
