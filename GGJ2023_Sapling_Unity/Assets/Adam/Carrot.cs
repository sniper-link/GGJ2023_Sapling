using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Minion
{
    public GameObject projectilePrefab;
    public CarrotPistol activeItem;
    public AmmoAndReload reloadScript;
    public float detectRadius;

    public Transform gunTip;

    public EnemyScript targetEnemy;

    float timeSinceActive, reloadTime, reloadDelay;
    bool reloading;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    public static GetClosestEnemy(Vector3 position, float maxRange){
        EnemyScript closest = null;
        Collider2D[] hitList = Physics2D.OverlapCircleAll(transform.position, detectRadius);
        float closetDistance = 100f;
        foreach (Collider2D hit in hitList) {
            if (Vector3.Distance(transform.position, hit.transform) <= closetDistance && hit.GetComponent<EnemyScript>().currentHealth > 0)
            {
                closetDistance = Vector3.Distance(transform.position, hit.transform);
                closest = hit.GetComponent<EnemyScript>();
            }
            // if enemy.IsDead()) continue;
            // if (Vector3.Distance(position, enemy.Getposition))
        }
        targetEnemy = closest;
    }

    void Shoot(CarrotPistol shootThis){
        timeSinceActive = 0;
        shootThis.setClip(shootThis.clipCurrent - shootThis.bulletCount);

        for (int i = 0; i < shootThis.bulletCount; i++){
            Vector3 dir = (Camera.main.ScreenToWorldPoint(targetEnemy.transform.position) - gunTip.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion LookDir = Quaternion.RotateTowards();
            float spread = Random.Range(-shootThis.bulletSpread, shootThis.bulletSpread);

            Quaternion projectileRotation = Quaternion.Euler(new Vector3(0, 0, angle + spread));

            GameObject projectile = (GameObject)GameObject.Instantiate(projectilePrefab, gunTip.position, projectileRotation);
            projectile.GetComponent<Projectile>().Setup(shootThis.damage, shootThis.bulletSpeed, shootThis.speedFallOff, shootThis.projectileSprite, this.gameObject.name, this.gameObject.layer);
        }
    }

    void Reload(){
        reloadScript.reloading = reloading;
        if (reloading){
            reloadDelay = activeItem.reloadTime;
            if(activeItem.clipCurrent > 0) reloadDelay -= 0.5f;
            reloadTime += Time.deltaTime;

            if (reloadTime > reloadDelay){
                if (activeItem.clipCurrent > 0) {
                    activeItem.setClip(activeItem.clipSize + activeItem.bulletCount);
                }
                else {
                    activeItem.setClip(activeItem.clipSize);
                }
                reloading = false;
            }
        }
    }

}
