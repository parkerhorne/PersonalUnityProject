using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currHealth;
    [SerializeField] private float armor = 0.0f;
    [SerializeField] private GameObject _deathParticlesObj;
    [SerializeField] private GameObject _player;
    void Awake()
    {
        _player = GameObject.Find("PlayerCapsule");
        EnemyInfo info = EnemyDataReader.RetrieveEnemyInfo(name);
        maxHealth = info.health;
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (currHealth <= 0.0f)
        {
            ParticleSystem _ps = _deathParticlesObj.GetComponent<ParticleSystem>();
            _deathParticlesObj.transform.position = transform.position;
            _ps.Play();
            Debug.Log("Enemy died!");
            EnemyDropManager _dropManager = GameObject.Find("EnemySpawnSystem").GetComponent<EnemyDropManager>();
            Instantiate(_dropManager.gemDrops[0], transform.position, Quaternion.identity);
            Destroy(GetComponent<MeshRenderer>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            WeaponInfo weaponData = JsonDataReader.RetrieveWeaponInfo(collision.gameObject.name);
            TakeDamage(weaponData.damage);
            // remove this if implementing pierce, probably keep array of colliding objects
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth _ph = _player.GetComponent<PlayerHealth>();
            EnemyInfo info = EnemyDataReader.RetrieveEnemyInfo(gameObject.name);
            _ph.TakeDamage(info.damage);
            Destroy(gameObject);
        }
    }
}
