using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TheSapling saplingRef;
    public RootSpawner rootSpawner;
    public MinionSpawner minionSpawner;
    public Spawner enemySpawner;
    static GameManager instance;

    public WaterText waterText;
    public int waterAmount = 0;
    public int poopAmount = 0;

    public List<int> minionWaterCost;
    public List<int> minionPoopCost;

    public GameObject waterPondPrefab;

    public int treeGrowLevel = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public static TheSapling GetSapling()
    {
        return instance.saplingRef;
    }

    public static RootSpawner GetRootSpawner()
    {
        return instance.rootSpawner;
    }

    public static MinionSpawner GetMinionSpawner()
    {
        return instance.minionSpawner;
    }

    public static void AddWater(int amount = 1)
    {
        
        instance.waterAmount += amount;
        instance.waterText.SetWaterText(instance.waterAmount);
    }

    public static int GetWater() { 
        return instance.waterAmount;
    }
    public static void AddPoop(int amount = 1)
    {
        instance.poopAmount += amount;
    }

    public static int GetMinionWaterCost(MinionIndex minionIndex)
    {
        return instance.minionWaterCost[(int)minionIndex];
    }

    public static int GetMinionPoopCost(MinionIndex minionIndex)
    {
        return instance.minionPoopCost[(int)minionIndex];
    }

    public static void SpawnWaterPonds()
    {
        // play rain vfx
        Vector2 randomSpot = new Vector2(Random.Range(0.1f, 0.9f), Random.Range(0.2f, 0.9f));
        Vector3 spawnLoc = Camera.main.ViewportToWorldPoint(randomSpot);
        spawnLoc.z = -0.1f;
        Instantiate(instance.waterPondPrefab, spawnLoc, Quaternion.identity, null);
    }

    public static void GrowTree()
    {
        // check if palyer have enough resources
        // if yes, add growth level
        // 5 level of growth

        if (instance.treeGrowLevel == 5)
        {
            Debug.Log("Game won");
        }
    }
}
