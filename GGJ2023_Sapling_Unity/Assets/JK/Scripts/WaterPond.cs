using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPond : MonoBehaviour


{
    //public GameObject pond;
    //WaterBar barRef;
    public SpriteRenderer newPond;
    //public Sprite changeWater;

    public List<Sprite> waterLevelSprite;

    public int currentWaterLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentWaterLevel = 10;
        //startingWater = 100;
    }

    // Update is called once per frame
    /*void Update()
    {
        //barValue = barRef.barVal;
       
        if (remainingWater == 50)
        {
            newPond.sprite = changeWater;
        }
        else if(remainingWater == 0) { 
            //Destroy(gameObject);
        }
    }*/

    public void DrainingWater()
    {
        StartCoroutine(WaterDraining());
    }

    IEnumerator WaterDraining()
    {
        while (currentWaterLevel > 0 )
        {
            Debug.Log("draining water");
            yield return new WaitForSeconds(1f);
            currentWaterLevel--;
            if (currentWaterLevel == 5)
            {
                // change sprites
                newPond.sprite = waterLevelSprite[1];
            }
            else if (currentWaterLevel == 0)
            {
                newPond.sprite = waterLevelSprite[2];
                yield return new WaitForSeconds(1.5f);
                Destroy(gameObject);
            }
        }
    }
}
