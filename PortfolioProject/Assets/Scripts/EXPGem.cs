using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPGem : MonoBehaviour
{
    [SerializeField] private int experience;
    
    void Start()
    {
        if (gameObject.name.Contains("XPGem1"))
        {
            experience = 2;
        }
        else if (gameObject.name.Contains("XPGem2"))
        {
            experience = 5;
        }
        else if (gameObject.name.Contains("XPGem3"))
        {
            experience = 100;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerEXPManager>().GainExperience(experience);
            Destroy(gameObject);
        }
    }
    
    // TODO: make oscillate for pretty polish effect wow!
}
