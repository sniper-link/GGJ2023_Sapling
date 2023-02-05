using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    float speed;
    bool speedFallOff = false;

    public string exclude;
    public SpriteRenderer projectileRenderer;

    public void Setup(int dmg, float spd, bool fallOff, Sprite sprite, string excludeName, LayerMask layer){

        damage = dmg;
        speed = spd;
        speedFallOff = fallOff;
        this.gameObject.layer = layer;
        exclude = excludeName;
        projectileRenderer.sprite = sprite;
    }

    void ONTriggerEnter2D(Collider2D other){
        if (other.name != exclude){
            Destory(this.gameObject);
        }
    }
}
