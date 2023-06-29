using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


[System.Serializable]
public class WeaponInfo
{
    public string name;
    public float damage;
    public int numLevels;
    public float fireRate;
    public float damageGrowth;
    public float quantityGrowth;
    public float  fireRateGrowth;
    public float  speedGrowth;
    public float  sizeGrowth;
}
[System.Serializable]
public class WeaponDataList
{
    public List<WeaponInfo> WeaponData;
}
public class JsonDataReader : MonoBehaviour
{
    [SerializeField] public TextAsset jsonFile;

    // Creating one static instance of the data reader
    private static JsonDataReader jsonReader;
    public static WeaponDataList weaponDataList;
    
    void Start()
    {
        if (!jsonFile)
        {
            jsonFile = Resources.Load<TextAsset>("WeaponData");
        }
        weaponDataList = LoadDataFromJson();
    }

    WeaponDataList LoadDataFromJson()
    {
        Assert.IsNotNull(jsonFile);

        WeaponDataList dataList = JsonUtility.FromJson<WeaponDataList>(jsonFile.text);

        foreach (WeaponInfo info in dataList.WeaponData)
        {
            Debug.Log("Weapon found: " + info.name);
        }
        return dataList;
    }

    public static WeaponInfo RetrieveWeaponInfo(string name)
    {
        foreach (WeaponInfo info in weaponDataList.WeaponData)
        {
            if (name.Contains(info.name))
            {
                return info;
            }
        }
        return null;
    }
}
