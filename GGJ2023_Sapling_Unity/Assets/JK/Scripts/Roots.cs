using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public bool canMove = false;
    public Vector3 targetLocation;
    public float moveSpeed = 1f;
    public float circleRad = 0.3f;
    public LayerMask resourceLayer;

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
                //Physics2D.CircleCast(transform.position, circleRad);
                Collider2D firstHit = Physics2D.OverlapCircle(transform.position, circleRad, resourceLayer);
                if (firstHit == null) {
                    Debug.Log("touched nothing");
                    return;
                }
                if (firstHit.TryGetComponent(out WaterPond waterPond))
                {
                    Debug.Log("water");
                    if (Vector3.Distance(targetLocation, transform.position) <= 0.2f)
                    {
                        waterPond.GetComponent<CircleCollider2D>().enabled = false;
                        waterPond.DrainingWater();
                        StartCoroutine(GiveWater());
                    }
                }
                else if (firstHit.TryGetComponent(out Poop poop))
                {
                    Debug.Log("poop");
                    if (Vector3.Distance(targetLocation, transform.position) <= 0.2f)
                    {
                        poop.GetComponent<CircleCollider2D>().enabled = false;
                        GameManager.AddPoop();
                        Destroy(poop.gameObject);
                        //StartCoroutine(GiveWater());
                    }
                }
                else
                {

                    //Destroy(this);
                    Debug.Log("thouched something else");
                }
                Debug.Log(firstHit.name);
                canMove = false;
                return;
            }

            //transform.position += ;
            Vector3 moveDir = targetLocation - transform.position;
            transform.position += (moveDir.normalized) * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator GiveWater()
    {
        int counter = 5;
        while (counter > 0)
        {
            yield return new WaitForSeconds(2f);
            counter--;
            GameManager.AddWater(1);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.TryGetComponent(out WaterPond waterPond))
        {
            Debug.Log("water");
            if (Vector3.Distance(targetLocation, transform.position) <= 0.2f)
            {
                waterPond.DrainingWater();
            }
        }
        else if (collision.TryGetComponent(out Poop poop))
        {
            Debug.Log("poop");
        }
        else
        {
            Destroy(this);
        }
    }*/
}
