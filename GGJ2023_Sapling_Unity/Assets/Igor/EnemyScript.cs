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
    float moveSpeed = 1;

    private void Awake()
    {
        
        SpriteRenderer sprRend;
        cc = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();


    }
    void Start()
    {
        saplingLoc = GameObject.Find("TheSapling").transform.position;
    }

    float dealDamange(float d) 
    {
        d = damage;
        return d;  
    }

    void moveToSapling(Vector2 location) {
        transform.position = Vector2.MoveTowards(transform.position, location, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TheSapling sapling)) {
            //change back to float
            sapling.TakeDamage((int)damage);
           // sapling.takeDamage(damage);
        }
        
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        moveToSapling(saplingLoc);
    }

}
