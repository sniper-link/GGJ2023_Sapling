using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public bool canMove = false;
    public Vector3 targetLocation;
    public float moveSpeed = 1f;

    public void MoveRoot(Vector2 targetLoction)
    {
        targetLocation = (Vector3)targetLoction;
        targetLocation.z = -0.1f;
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            if (Vector3.Distance(targetLocation, transform.position) <= 0.2f)
            {
                canMove = false;
                return;
            }

            //transform.position += ;
            Vector3 moveDir = targetLocation - transform.position;
            transform.position += (moveDir.normalized) * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.TryGetComponent(out WaterPond waterPond))
        {
            Debug.Log("water");
        }
        else if (collision.TryGetComponent(out Poop poop))
        {
            Debug.Log("poop");
        }
        else
        {
            Destroy(this);
        }
    }
}
