using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSapling : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth;
    public float currentHealth;
    public SpriteRenderer saplingSprite;
    public List<Sprite> growthSprite;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(2);
        }
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth < 0){
            currentHealth = 0;
            GameManager.GameOver();
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

    public void UpdateGrowth(int growthLevel)
    {
        saplingSprite.sprite = growthSprite[growthLevel];
    }
}
