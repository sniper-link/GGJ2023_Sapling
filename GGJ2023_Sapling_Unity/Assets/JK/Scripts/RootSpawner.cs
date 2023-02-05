using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour
{
    public GameObject rootsPrefab;
    public Vector2 startLocation;
    public GameObject rootsFolder;
    public Vector2 testLoc;

    public float rootSpawnZ = -0.1f;

    private void Start()
    {
        startLocation = (Vector2)GameManager.GetSapling().transform.position;
        
        //SpawnRoots(testLoc);
    }

    public void SpawnRoots(Vector2 targetLocation)
    {
        Vector3 targetLoc = (Vector3)targetLocation;
        targetLoc.z = -0.1f;

        if (rootsFolder.transform.childCount > 25)
        {
            Destroy(rootsFolder.transform.GetChild(0));
        }
        Vector3 spawnLoction = startLocation;
        spawnLoction.z = rootSpawnZ;
        Instantiate(rootsPrefab, spawnLoction, Quaternion.identity, rootsFolder.transform).GetComponent<Roots>().MoveRoot(targetLoc);
    }
}
