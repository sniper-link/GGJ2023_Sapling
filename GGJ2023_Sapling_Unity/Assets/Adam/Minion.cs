using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth;
    public float currentHealth;
    public float damage;

    public GameObject deathSmokeVFX;

    private bool canAttack = true;

    private Animator minionAnimator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        minionAnimator = GetComponent<Animator>();
        Vector3 faceDir = GameManager.GetSapling().transform.position - transform.position;
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = faceDir.x < 0;
        }
        
        //Debug.Log(faceDir.x);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            TakeDamage(2);
        }
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0){
            //currentHealth = 0;
            DeathEvents();
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

    protected virtual void AttackEvents()
    {
        //minionAnimator.SetTrigger("Attack");
    }

    protected virtual void DeathEvents()
    {
        Instantiate(deathSmokeVFX, transform.position, Quaternion.identity, null);
        Destroy(this);
    }

    public void CallOnDestroy()
    {
        Destroy(this);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyScript enemy))
        {
            canAttack = false;
            AttackEvents();
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyScript enemy))
        {
            canAttack = true;
            AttackEvents();
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
