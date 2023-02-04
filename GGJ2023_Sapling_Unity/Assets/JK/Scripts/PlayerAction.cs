using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Camera targetCamera;
    public Roots rootSpawner;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray2D mouseRay = targetCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if(hit.transform.TryGetComponent(out WaterPond waterPond))
                {
                    // send out roots
                    //rootSpawner.SpawnRoots((Vector2)hit.transform.position);
                }
                else if(hit.transform.TryGetComponent(out Poop poop))
                {
                    // send out roots
                }
                else
                {
                    // spawn minion test
                }

                
                //Debug.Log(hit.transform.position);
            }
        }
    }
}
