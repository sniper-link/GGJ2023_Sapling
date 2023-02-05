using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text waterCounter, poopCounter, treeLevelText;

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

    private void Start()
    {
        instance.waterCounter.text = instance.waterAmount.ToString();
        instance.poopCounter.text = instance.poopAmount.ToString();
        instance.treeLevelText.text = instance.treeGrowLevel.ToString();
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
        instance.waterCounter.text = instance.waterAmount.ToString();
        //instance.waterText.SetWaterText(instance.waterAmount);
    }

    public static int GetWater() { 
        return instance.waterAmount;
    }
    public static void AddPoop(int amount = 1)
    {
        instance.poopAmount += amount;
        instance.poopCounter.text = instance.poopAmount.ToString();
    }

    public static int GetMinionWaterCost(MinionIndex minionIndex)
    {
        return instance.minionWaterCost[(int)minionIndex];
    }

    public static int GetMinionPoopCost(MinionIndex minionIndex)
    {
        return instance.minionPoopCost[(int)minionIndex];
    }

    public static bool CanSpawnMinion(MinionIndex minionIndex)
    {
        return (instance.waterAmount >= instance.minionWaterCost[(int)minionIndex]) && (instance.poopAmount >= instance.minionPoopCost[(int)minionIndex]);
    }

    public static void UseMinionCost(MinionIndex minionIndex)
    {
        if ((instance.waterAmount >= instance.minionWaterCost[(int)minionIndex]) && (instance.poopAmount >= instance.minionPoopCost[(int)minionIndex]))
        {
            instance.waterAmount -= instance.minionWaterCost[(int)minionIndex];
            instance.poopAmount -= instance.minionPoopCost[(int)minionIndex];
            instance.waterCounter.text = instance.waterAmount.ToString();
            instance.poopCounter.text = instance.poopAmount.ToString();
        }
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

        if (instance.waterAmount >= 30 && instance.poopAmount >= 10)
        {
            instance.waterAmount -= 30;
            instance.poopAmount -= 10;
            instance.waterCounter.text = instance.waterAmount.ToString();
            instance.poopCounter.text = instance.poopAmount.ToString();
            instance.treeGrowLevel++;
            if (instance.treeGrowLevel == 2)
            {
                instance.saplingRef.UpdateGrowth(1);
            }
            else if (instance.treeGrowLevel == 4)
            {
                instance.saplingRef.UpdateGrowth(2);
            }
            else if (instance.treeGrowLevel == 5)
            {
                Debug.Log("Game won");
            }
        }

        
    }

    public static void GameReset()
    {
        instance.waterAmount = 10;
        instance.poopAmount = 0;
    }

    public static void GameOver()
    {
        // display a game over screen
        Time.timeScale = 0f;
    }
}
