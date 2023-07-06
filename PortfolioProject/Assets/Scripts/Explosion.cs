using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool _timerStarted;
    private float _radius;
    private float _delay;
    private float _damage;

    private int _layerMask;
    [SerializeField] private GameObject _particles;

    private void Start()
    {
        // enemy is layer 6
        _layerMask = (1 << 6);
    }
    public void Update()
    {
        if (_timerStarted)
        {
            _delay -= Time.deltaTime;
            if (_delay <= 0.0f)
            {
                Debug.Log("Bomb Exploded");
               Collider[] enemiesHit = Physics.OverlapSphere(transform.position, _radius, _layerMask);
               foreach (Collider col in enemiesHit)
               {
                   EnemyHealth health = col.GetComponent<EnemyHealth>();
                   health.TakeDamage(_damage);
               }

               _particles.transform.position = transform.position;
               _particles.GetComponent<ParticleSystem>().Play();
               Destroy(GetComponent<Rigidbody>());
               foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
               {
                   Destroy(renderer);
               }
               Destroy(gameObject, 1);
            }
        }
    }

    public void Explode(float radius, float delay, float damage)
    {
        _timerStarted = true;
        _radius = radius;
        _delay = delay;
        _damage = damage;
    }
}
