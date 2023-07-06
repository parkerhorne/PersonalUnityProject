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
        bomb.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3f, 3f),
            Random.Range(0f, 2f), Random.Range(-3f, 3f)), ForceMode.Impulse);
        Explosion explosion = bomb.GetComponent<Explosion>();
        explosion.Explode(5f, 1.5f, damage);
    }

    public override void Upgrade()
    {
        
    }
}
