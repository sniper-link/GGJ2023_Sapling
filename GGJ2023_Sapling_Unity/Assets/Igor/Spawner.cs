using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public float spawnRangeXMin;
    public float spawnRangeXMax;
    public float spawnRangeYMin;
    public float spawnRangeYMax;

    public float SpawnCd;

    public int numToSpawnPerInterval = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(SpawnCd, enemyList));
    }

    private IEnumerator spawnEnemy(float interval, List<GameObject> enemy) {

        print("starting");

        for (int i = 0; i <= numToSpawnPerInterval; i++)
        {
            int selectEnemy = Random.Range(0, enemyList.Count - 1);
            Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(spawnRangeXMin, spawnRangeXMax),Random.Range(spawnRangeYMin, spawnRangeYMax), 0.5f));
            v3Pos.z = -0.2f;
            GameObject spawn = Instantiate(enemy[selectEnemy], v3Pos, Quaternion.identity);

        }
        yield return new WaitForSeconds(2f);
        GameManager.SpawnWaterPonds();
        yield return new WaitForSeconds(interval);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
