using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TheSapling saplingRef;
    public RootSpawner rootSpawner;
    public MinionSpawner minionSpawner;
    static GameManager instance;

    public WaterText waterText;
    public int waterAmount = 0;
    public int poopAmount = 0;

    public List<int> minionWaterCost;
    public List<int> minionPoopCost;

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
}
