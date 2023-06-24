using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float _spawnRangeX;
    private float _spawnRangeY;
    
    [SerializeField] private List<GameObject> enemyList;

    [SerializeField] private float maxSpawnCost;
    [SerializeField] private float currentSpawnCost;
    
    void Start()
    {
        // Get size of floor to know the range of valid spawn locations.
        GameObject floor = GameObject.FindWithTag("Floor");
        if (floor)
        {
            _spawnRangeX = floor.transform.localScale.x;
            _spawnRangeY = floor.transform.localScale.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

