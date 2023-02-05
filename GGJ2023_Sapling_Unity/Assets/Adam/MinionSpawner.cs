using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//const float spawnZ = -0.2f;

public enum MinionIndex 
{
    Onion = 0,
    Carrort = 1,
    Acorn = 2,
    Mushroom = 3,
}

public class MinionSpawner : MonoBehaviour
{
    
    public List<GameObject> MinionList;
    public Vector2 testloc;
    //Vector2 clickLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // void Start()
    // {
    //     spawnMinion(MinionIndex.Onion, testloc);
    // }
    public void spawn(){
        spawnMinion(MinionIndex.Onion, testloc);
    }

    public void spawnMinion(MinionIndex minionIndex, Vector2 spawnLocation) {
        // (int)minionIndex;
        // for (int i = 0; i < count; i++) {
        //     Vector3 spawnPos = this.transform.position;
        //     Vector3 randRange = new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0);
        //     spawnPos += randRange;

        //     GameObject newEnemy = Instantiate(newEnemy, spawnPos, Quaternion.identity);
        // }
        // StartCoroutine(spawnMinion(Minion, count));
        Vector3 v3SpawnLoc = spawnLocation;
        v3SpawnLoc.z = -0.2f;
        Instantiate(MinionList[(int) minionIndex], v3SpawnLoc, Quaternion.identity);
    }
}
