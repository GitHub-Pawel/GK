﻿
using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    
    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int healValue)
    {
        healValue = Mathf.Clamp(healValue, 0, maxHealth-currentHealth);
        currentHealth += healValue;
    }
    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            //Die
            Debug.Log(transform.name + " died.");
        }
    }
}
