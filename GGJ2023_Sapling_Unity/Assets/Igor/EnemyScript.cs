using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float enemyDamage = 1;
    public CircleCollider2D cc;
    public Rigidbody2D rb;
    public Vector2 saplingLoc;
    //public TheSapling saplingRef;
    public float moveSpeed = 5;

    public GameObject deathSmokeVFX;

    public Minion targetMinion = null;
    public bool canAttack = true;

    private void Awake()
    {
        currentHealth = maxHealth;
       // SpriteRenderer sprRend;
        //cc = gameObject.GetComponent<CircleCollider2D>();
        //rb = gameObject.GetComponent<Rigidbody2D>();


    }
    void Start()
    {
        //saplingRef  = GameManager.GetSapling();
        saplingLoc = GameManager.GetSapling().transform.position;
        Vector2 faceDir = saplingLoc - (Vector2)transform.position;
        GetComponent<SpriteRenderer>().flipX = faceDir.x >= 0;
        Debug.Log("enemy: " + faceDir.x);
    }

    float dealDamange(float d) 
    {
        d = enemyDamage;
        return d;  
    }

    void moveToSapling(Vector2 location) {
        Vector2 moveDir = location - (Vector2)transform.position;
        transform.position += ((Vector3)moveDir).normalized * Time.deltaTime * moveSpeed;
        //Debug.Log(moveDir);
        //moveDir = Vector2.MoveTowards(transform.position, location, 1f)*Time.deltaTime*moveSpeed;
    }

    void MoveToTargetMinion()
    {
        if (Vector3.Distance(targetMinion.transform.position, transform.position) < 0.1f)
        {
            // attack
            AttackMinion();
        }
        else
        {
            // move
            Vector3 moveDir = (targetMinion.transform.position - transform.position);
            transform.position += moveDir.normalized * Time.deltaTime * moveSpeed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogWarning(collision.name);
        if (collision.TryGetComponent(out TheSapling sapling)) {
            //change back to float
            Debug.LogWarning("Hit the Tree");
            Destroy(gameObject);
            sapling.TakeDamage(enemyDamage);
            
           // sapling.takeDamage(damage);
        }
        
    }

    protected virtual void DeathEvents() 
    {
        
        StartCoroutine(DeathDelay(Instantiate(deathSmokeVFX, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity, null)));
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            return;
        }

        if (!targetMinion)
        {
            moveToSapling(saplingLoc);
        }
        else
        {
            MoveToTargetMinion();
        }
    }

    public void TakeDamage(float amount, Minion attackingMinion = null)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            //currentHealth = 0;
            DeathEvents();
            return;
        }

        if (!targetMinion)
        {
            targetMinion = attackingMinion;
        }
        //healthBar.SetHealth(currentHealth);
    }

    IEnumerator DeathDelay(GameObject expVFX)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(expVFX);
    }

    void AttackMinion()
    {
        if (canAttack)
        {
            canAttack = false;
            targetMinion.TakeDamage(enemyDamage);
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
