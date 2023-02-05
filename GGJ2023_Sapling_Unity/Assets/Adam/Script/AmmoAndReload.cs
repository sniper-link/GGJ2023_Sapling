using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAndReload : MonoBehaviour
{
    public CarrotPistol activeItem;
    //public Text ammoText;
    public bool reloading = false;

    //public void Update()
    //{
        //if (reloading)
        //{
            //if (activeItem != null) ammoText.text = "Reloading...";
        //}
        //else
        //{
        //    if (activeItem != null) ammoText.text = "Ammo:" + activeItem.clipCurrent;
        //}
    //}

    public void Setup()
    {
        //if (activeItem != null)
        //{
        //    ammoText.text = "" + activeItem.clipCurrent;
        //}
    }
}
