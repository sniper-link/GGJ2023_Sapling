using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentBullet : MonoBehaviour
{
    public float moveSpeed;
    public EnemyScript targetEnemy;
    public float despawnTimer;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null)
        {
            despawnTimer += Time.deltaTime;
            if (despawnTimer > 1f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Vector3 moveDir = (targetEnemy.transform.position - transform.position).normalized;
            transform.position += (moveDir * moveSpeed * Time.deltaTime);
            Vector3 targetEnemyLevelPos = targetEnemy.transform.position;
            targetEnemyLevelPos.z = transform.position.z;
            transform.LookAt(targetEnemyLevelPos);
        }
    }

    public void UpdateTargetEnemy(EnemyScript newTargetEnemy)
    {
        targetEnemy = newTargetEnemy;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyScript someTarget))
        {
            someTarget.TakeDamage(1f);
            Destroy(this.gameObject);
        }
    }
}
