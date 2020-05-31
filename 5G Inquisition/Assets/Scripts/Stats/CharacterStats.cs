
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public SceneSwitcher sceneSwitcher;
    public Stat damage;
    public Stat armor;
    public Stat healing;
    public PostProcessingController postProcessingController;

    private void Start()
    {
        postProcessingController = GetComponent<PostProcessingController>();
    }

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
        postProcessingController.UpdatePostProcessing();
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            sceneSwitcher.GameOver();
            Debug.Log(transform.name + " died.");
        }
    }

    public int GetHealthLost()
    {
        return maxHealth - currentHealth;
    }
}
