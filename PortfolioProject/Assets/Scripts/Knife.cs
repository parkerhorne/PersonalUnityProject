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
    private int _quantity = 1;
    private float _scaleRatio = 1;
    void Start()
    {
        damage = 10.0f;
        size = 1.0f;
        currLevel = 1;
        numLevels = 5;
        fireRate = 1.5f;
        
        _player = GameObject.Find("PlayerCapsule");
        _prefab = Resources.Load<GameObject>("Knife");
        _quantity = 1;
    }

    public override void Attack()
    {
        Vector3 direction = SelectTargetDirection();
        if (direction == Vector3.zero)
        {
            return;
        }
        
        for (int i = 0; i < _quantity; i++)
        {
            Vector3 offset = Vector3.zero;
            if (_quantity > 1)
            {
                offset = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
            }
            GameObject knife = Instantiate(_prefab, _player.transform.position + offset, Quaternion.Euler(90, 0, -90));
            knife.transform.localScale *= _scaleRatio;
            Destroy(knife, 10);
            Rigidbody _rb = knife.GetComponent<Rigidbody>();
            _rb.velocity = direction * _speed;
        }
    }

    public override void Upgrade()
    {
        ++currLevel;
        WeaponInfo info = JsonDataReader.RetrieveWeaponInfo("Knife");
        damage *= info.damageGrowth;
        _speed *= info.speedGrowth;
        fireRate /= info.fireRateGrowth;
        _scaleRatio *= info.sizeGrowth;
        ++_quantity;

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

    private void LateUpdate()
    {
        // TESTING
        if (Input.GetKeyDown(KeyCode.M))
        {
            Upgrade();
            Debug.Log("Upgraded Knife, damage now: " + damage);
        }
    }
    
}
