using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _player;
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // TODO: use a coroutine to optimize basic enemy pathfinding to player.
}
