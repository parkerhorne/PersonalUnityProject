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
    void Awake()
    {
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
    }
}
