using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEXPManager : MonoBehaviour
{
    [SerializeField] private int playerLevel;

    [SerializeField] private int maxLevel;

    [SerializeField] private float currentExp;

    [SerializeField] private float[] expThresholds;

    [SerializeField] private RectTransform _expBar;

    [SerializeField] private TextMeshProUGUI _levelText;
    
    
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

        _expBar = GameObject.Find("XPBar").GetComponent<RectTransform>();
        _levelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        _levelText.text = $"Lv. 0";

    }


    public void GainExperience(float amt)
    {
        currentExp += amt;
        if (playerLevel == 0)
        {
            Vector3 expOffset = new Vector3(100 * (amt / expThresholds[playerLevel]), 0, 0);
            _expBar.localPosition += expOffset;
        }
        else
        {
            Vector3 expOffset = new Vector3(100 * (amt / (expThresholds[playerLevel] - expThresholds[playerLevel - 1])), 0, 0);
            _expBar.localPosition += expOffset;
        }
        
        HandleLevelUp();
    }

    private void HandleLevelUp()
    {
        if (currentExp >= expThresholds[playerLevel])
        {
            // execute level up code here
            ++playerLevel;
            Debug.Log("Level up, player level now " + playerLevel);
            _levelText.text = $"Lv. {playerLevel}";
            // TODO: fix how this works when there is extra exp left over on level up (e.g. 75 -> 76 exp)
            _expBar.localPosition = new Vector3(-100, _expBar.localPosition.y, _expBar.localPosition.z);
        }

        // potentially dangerous recursion
        while (currentExp >= expThresholds[playerLevel])
        {
            HandleLevelUp();
        }
    }
}
