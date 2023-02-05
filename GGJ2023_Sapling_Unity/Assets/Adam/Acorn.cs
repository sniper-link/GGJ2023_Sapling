using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : Minion
{
    public GameObject acornExplosionVFX;
    public float blastRadius = 1.5f;

    public void CallOnExplode()
    {
        GameObject expVFX = Instantiate(acornExplosionVFX, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity, null);
        Collider2D[] hitList = Physics2D.OverlapCircleAll(transform.position, blastRadius);
        foreach (Collider2D collider in hitList)
        {
            if (collider.TryGetComponent(out EnemyScript enemy))
            {
                //enemy.
                enemy.TakeDamage(3);
            }
        }
        StartCoroutine(DeathDelay(expVFX));
       
    }

    IEnumerator DeathDelay(GameObject expVFX)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(expVFX);
    }
}
