using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TheSapling saplingRef;
    public RootSpawner rootSpawner;
    static GameManager instance;

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
}
