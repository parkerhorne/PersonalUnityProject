using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class EnemyInfo
{
    public string name;
    public int cost;
    public float health;
    public float speed;
}
[System.Serializable]
public class EnemyDataList
{
    public List<EnemyInfo> EnemyData;
}
public class EnemyDataReader : MonoBehaviour
{
    [SerializeField] public TextAsset jsonFile;

    // Creating one static instance of the data reader
    private static EnemyDataReader enemyDataReader;
    public EnemyDataList enemyDataList;
    
    void Start()
    {
        if (!jsonFile)
        {
            jsonFile = Resources.Load<TextAsset>("EnemyData");
        }
        enemyDataList = LoadDataFromJson();
    }

    EnemyDataList LoadDataFromJson()
    {
        Assert.IsNotNull(jsonFile);

        EnemyDataList dataList = JsonUtility.FromJson<EnemyDataList>(jsonFile.text);

        foreach (EnemyInfo info in dataList.EnemyData)
        {
            Debug.Log("Enemy found: " + info.name);
        }
        return dataList;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
