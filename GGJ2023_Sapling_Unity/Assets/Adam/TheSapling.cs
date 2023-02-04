using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSapling : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth < 0){
            currentHealth = 0;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(float health) {
        currentHealth += health;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }


}
