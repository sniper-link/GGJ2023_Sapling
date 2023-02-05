using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooom : Minion
{
    public float blastRadius = 0.5f;

    public void CallOnAttack()
    {
        Collider2D[] hitList = Physics2D.OverlapCircleAll(transform.position, blastRadius);
        foreach (Collider2D collider in hitList)
        {
            if (collider.TryGetComponent(out EnemyScript enemy))
            {
                //enemy.
                enemy.TakeDamage(1);
            }
        }
        //StartCoroutine(DeathDelay(expVFX));
    }
}
