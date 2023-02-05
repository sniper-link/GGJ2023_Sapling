using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public MinionSpawner minionSpawner;
    public Camera targetCamera;
    //public Roots rootSpawner;
    public RootSpawner rootSpawner;

    private void Start()
    {
        rootSpawner = GameManager.GetRootSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("ree");
            //Ray2D mouseRay = targetCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //Transform s = null;
            //s.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 clickLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(hit);
            if (hit)
            {
                if(hit.transform.TryGetComponent(out WaterPond waterPond))
                {
                    // send out roots
                    //rootSpawner.SpawnRoots((Vector2)hit.transform.position);
                    rootSpawner.SpawnRoots((Vector2)hit.transform.position);
                }
                else if(hit.transform.TryGetComponent(out Poop poop))
                {
                    // send out roots
                    rootSpawner.SpawnRoots((Vector2)hit.transform.position);
                }
                else
                {
                    // spawn minion test
                    minionSpawner.spawnMinion(MinionIndex.Carrort, clickLoc);
                }

                
                Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
