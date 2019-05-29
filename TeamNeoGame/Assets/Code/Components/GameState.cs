/******************************************************************************
    Game State
    William Siauw
    This script contains the information that needs to be kept throughout the entire game
******************************************************************************/
using Assets.Code.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Vector3 Player = new Vector3(0,0,0);
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
}
