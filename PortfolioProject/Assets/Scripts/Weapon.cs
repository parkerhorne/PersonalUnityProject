using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;
    public float size;
    // Time in seconds between firing
    public float fireRate;
    public int numLevels;
    public int currLevel;
    
    private float _attackTimer;
    
    

    public abstract void Attack();

    public abstract void Upgrade();

    private void Start()
    {
        _attackTimer = fireRate;
    }

    public void Update()
    {
        _attackTimer -= Time.deltaTime;
        if (_attackTimer <= 0.0f)
        {
            Attack();
            _attackTimer = fireRate;
        }
    }
}
