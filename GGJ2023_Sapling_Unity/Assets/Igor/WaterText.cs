using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterText : MonoBehaviour

    
{
    GameManager GM;
    int storeValue;
    public GameObject getText;
    Text showText;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
        StartCoroutine(showingText());
        showText = getText.GetComponent<Text>();
        showText.text = "0";
    }

    IEnumerator showingText() {
        Debug.Log("showtext");
        yield return new WaitForSeconds(0.1f);
        storeValue = GameManager.GetWater();
        
    }

    public void SetWaterText(int water)
    {
        showText = getText.GetComponent<Text>();
        showText.text = water.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
       // text = storeValue.ToString();
        //showText = text;
    }
}
