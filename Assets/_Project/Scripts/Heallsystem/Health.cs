using System;
using UnityEngine;
using UnityEngine.Assemblies;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float currentHealth;

    public float CurrentHealth => currentHealth;
    public Action<float, float> OnHealChanged;
    public Action<>

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"HP: {currentHealth}/{maxHealth}"); // 100/100 ES
        OnHealChanged? Invok(currentHealth ,maxHealth)

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;

        Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void SerHealth(float _health, float _maxHealth)
    {
        currentHealth = _health;
        maxHealth = _maxHealth;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
