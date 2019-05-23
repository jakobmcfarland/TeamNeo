using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Vector3 Player = new Vector3(0,0,0);
    public int MaxHealth;
    public static int curHealth;
    [HideInInspector]
    public bool ReadyToBattle;

    [HideInInspector]
    public bool Loaded = false;

    static GameState instance;
    public static GameState GetInstance()
    { return instance; }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this.gameObject);
        CombatInfo.MaxHealth = MaxHealth;
    }
    public void LoadGame()
    {
        for (int i = 0; i < CombatInfo.CombatsFinished; i++)
        {
            MapNodeManager.GetInstance().nodes[i].nodeState = NodeState.Current;
        }
        print(CombatInfo.HealthPotionCount);
    }
}
