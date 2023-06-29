using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float _spawnRangeX;
    private float _spawnRangeY;
    
    [SerializeField] private List<GameObject> enemyList;

    [SerializeField] private float maxSpawnCost;
    [SerializeField] private float currentSpawnCost;

    private float test_timer = 1.0f;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _testEnemy;
    private Vector3 _randomSpawnPosition;
    
    void Start()
    {
        _randomSpawnPosition = new Vector3(0f, 0f, 0f);
        // Get size of floor to know the range of valid spawn locations.
        GameObject floor = GameObject.FindWithTag("Floor");
        if (floor)
        {
            _spawnRangeX = floor.transform.localScale.x * 5.0f;
            _spawnRangeY = floor.transform.localScale.y * 5.0f;
        }

        _player = GameObject.Find("PlayerCapsule");
    }

    float PlayerDistance(Vector3 pos)
    {
        return Vector3.Distance(_player.transform.position, pos);
    }
    // Update is called once per frame
    void Update()
    {
        test_timer -= Time.deltaTime;
        if (test_timer <= 0.0f)
        {
            do
            {
                _randomSpawnPosition = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0,
                    Random.Range(-_spawnRangeY, _spawnRangeY));
            } while (PlayerDistance(_randomSpawnPosition) < 15.0f);
            //Debug.Log("Distance: " + PlayerDistance(_randomSpawnPosition));
            Instantiate(_testEnemy, _randomSpawnPosition, Quaternion.identity);
            test_timer = 2.0f;
        }
    }
}

