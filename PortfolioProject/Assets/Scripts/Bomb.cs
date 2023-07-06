using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
    private GameObject _prefab;

    private WeaponInfo info;
    void Start()
    {
        _prefab = Resources.Load<GameObject>("Bomb");
        info = JsonDataReader.RetrieveWeaponInfo("Bomb");
        damage = info.damage;
        numLevels = info.numLevels;
        fireRate = info.fireRate;
        currLevel = 1;
    }
    public override void Attack()
    {
        GameObject bomb = Instantiate(_prefab, transform.position, Quaternion.identity);
        Explosion explosion = bomb.GetComponent<Explosion>();
        explosion.Explode(15f, 1.5f, damage);
    }

    public override void Upgrade()
    {
        
    }
}
