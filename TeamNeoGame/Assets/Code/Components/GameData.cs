/******************************************************************************
    Game Data
    William Siauw
    This script contains the constructor for the data the game will save.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int CombatsFinished;
    public float[] mapPos;
    public int healthPotions;
    public int health;
    public GameData(Vector3 pos, int combats)
    {
        mapPos = new float[3];
        CombatsFinished = combats;

        mapPos[0] = pos.x;
        mapPos[1] = pos.y;
        mapPos[2] = pos.z;
        mapPos[2] = pos.z;
        healthPotions = CombatInfo.HealthPotionCount;
        health = GameState.curHealth;
    }
}
