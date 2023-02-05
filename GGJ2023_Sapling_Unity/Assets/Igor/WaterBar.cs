using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Slider waterBar;
    public float barVal = 50;
    // Start is called before the first frame update
    void Start()
    {
        waterBar.interactable = false;
        waterBar.minValue = 0;
        waterBar.maxValue = 100;
        waterBar.value = barVal;
    }

    // Update is called once per frame
    void Update()
    {
        barVal -= (float)(1.5 * Time.deltaTime);
        waterBar.value = barVal;
    }
}
