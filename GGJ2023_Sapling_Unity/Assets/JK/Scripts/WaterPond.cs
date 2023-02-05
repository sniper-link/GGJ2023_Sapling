using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPond : MonoBehaviour


{
    public GameObject pond;
    WaterBar barRef;
    float startingWater;
    float remainingWater;
    public SpriteRenderer newPond;
    public Sprite changeWater;
    // Start is called before the first frame update
    void Start()
    {
        startingWater = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //barValue = barRef.barVal;
       
        if (remainingWater == 50)
        {
            newPond.sprite = changeWater;
        }
        else if(remainingWater == 0) { 
            Destroy(gameObject);
        }
    }
}
