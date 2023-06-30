using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEXPManager : MonoBehaviour
{
    [SerializeField] private int playerLevel;

    [SerializeField] private int maxLevel;

    [SerializeField] private float currentExp;

    [SerializeField] private float[] expThresholds;
    
    
    void Start()
    {
        playerLevel = 0;
        currentExp = 0;
        expThresholds = new float[]
        {
            10, 20, 30, 40, 50, 75, 100, 150, 200, 300, 500,
            750, 1000, 1300, 1600, 2000, 2500, 3000, 3500, 4000,
            5000, 6000, 7500, 10000
        };
        maxLevel = expThresholds.Length;
    }


    public void GainExperience(float amt)
    {
        currentExp += amt;
        HandleLevelUp();
    }

    private void HandleLevelUp()
    {
        if (currentExp >= expThresholds[playerLevel])
        {
            // execute level up code here
            ++playerLevel;
            Debug.Log("Level up, player level now " + playerLevel);
        }

        // potentially dangerous recursion
        while (currentExp >= expThresholds[playerLevel])
        {
            HandleLevelUp();
        }
    }
}
