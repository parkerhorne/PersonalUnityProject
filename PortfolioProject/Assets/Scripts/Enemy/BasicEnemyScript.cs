using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EnemyState
{
    Spawning,
    Attacking
}
public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float spawnTimer = 1.5f;
    private EnemyState _state;
    
    void Start()
    {
        _player = GameObject.Find("PlayerCapsule");
    }

    void Awake()
    {
        _state = EnemyState.Spawning;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (_state == EnemyState.Attacking)
        {
            StartCoroutine(FollowPlayer());
        }

        if (_state == EnemyState.Spawning && spawnTimer <= 0.0f)
        {
            _state = EnemyState.Attacking;
        }
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
