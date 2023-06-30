using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private float currentHealth = 100f;

    [SerializeField] private float armorValue = 0f;

    
    [SerializeField] private RectTransform _healthBar;

    [SerializeField] private TextMeshProUGUI _healthText;
    
    void Start()
    {
        _healthBar = GameObject.Find("HealthBarHP").GetComponent<RectTransform>();
        _healthText = GameObject.Find("HPText").GetComponent<TextMeshProUGUI>();
        _healthText.text = $"{currentHealth} / {maxHealth}";
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Vector3 healthOffset = new Vector3((currentHealth - maxHealth), 0, 0);
        _healthBar.localPosition = healthOffset;
        _healthText.text = $"{currentHealth} / {maxHealth}";
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (currentHealth <= 0.0f)
        {
            // this will be improved later
            Debug.Log("Player died");
            currentHealth = maxHealth;
        }
    }
}
