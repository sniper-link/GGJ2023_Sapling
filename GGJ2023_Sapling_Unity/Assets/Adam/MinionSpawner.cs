using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        spawnMinion(MinionIndex.Mushroom, testloc);
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
        Instantiate(MinionList[(int) minionIndex], (Vector3)spawnLocation, Quaternion.identity);
    }
}
