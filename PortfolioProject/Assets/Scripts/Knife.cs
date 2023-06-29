using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Knife : Weapon
{
    private GameObject _player;
    [SerializeField] private GameObject _prefab;
    private float _speed = 10.0f;
    void Start()
    {
        damage = 10.0f;
        size = 1.0f;
        currLevel = 1;
        numLevels = 5;
        fireRate = 1.5f;
        
        _player = GameObject.Find("PlayerCapsule");
        _prefab = Resources.Load<GameObject>("Knife");
    }

    public override void Attack()
    {
        Vector3 direction = SelectTargetDirection();
        if (direction == Vector3.zero)
        {
            return;
        }
        GameObject knife = Instantiate(_prefab, _player.transform.position, Quaternion.identity);
        Destroy(knife, 10);
        Rigidbody _rb = knife.GetComponent<Rigidbody>();
        _rb.velocity = direction * _speed;
    }

    private Vector3 SelectTargetDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            return Vector3.zero;
        }
        int target_index = Random.Range(0, enemies.Length - 1);
        return Vector3.Normalize(enemies[target_index].transform.position - _player.transform.position);
    }
    
}
