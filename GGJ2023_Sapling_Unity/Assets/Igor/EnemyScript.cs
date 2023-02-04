using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float damage;
    public CircleCollider2D cc;
    public Rigidbody2D rb;
    public Vector2 saplingLoc;
    //public TheSapling saplingRef;
    public float moveSpeed = 5;

    private void Awake()
    {
        
        SpriteRenderer sprRend;
        //cc = gameObject.GetComponent<CircleCollider2D>();
        //rb = gameObject.GetComponent<Rigidbody2D>();


    }
    void Start()
    {
        //saplingRef  = GameManager.GetSapling();
        saplingLoc = GameManager.GetSapling().transform.position;
        CircleCollider2D uisdgf = GetComponent<CircleCollider2D>();
        if (uisdgf)
        {
            Debug.Log("sdnbfgjksdg");
        }
    }

    float dealDamange(float d) 
    {
        d = damage;
        return d;  
    }

    void moveToSapling(Vector2 location) {
        Vector2 moveDir = location - (Vector2)transform.position;
        transform.position += ((Vector3)moveDir).normalized * Time.deltaTime * moveSpeed;
        //Debug.Log(moveDir);
        //moveDir = Vector2.MoveTowards(transform.position, location, 1f)*Time.deltaTime*moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning(collision.name);
        if (collision.TryGetComponent(out TheSapling sapling)) {
            //change back to float
            Debug.LogWarning("Hit the Tree");
            Destroy(gameObject);
            sapling.TakeDamage((int)damage);
            
           // sapling.takeDamage(damage);
        }
        
    }

    private void DeathEvents() {
        
        Destroy(gameObject); 
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning(collision.gameObject.name);
    }
    
    // Update is called once per frame
    void Update()
    {
        moveToSapling(saplingLoc);
    }

}
