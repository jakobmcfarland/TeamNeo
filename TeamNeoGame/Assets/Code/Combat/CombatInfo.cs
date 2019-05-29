using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatInfo
{
    public  static int CombatsFinished;
    public static string EnemyName { get; set; }
    public static Sprite EnemySprite { get; set; }
    public static int PlayerDamage { get; set; }
    //The damage an enemy does per missed arrow
    public static int EnemyDamage { get; set; }
    //The stamina gained per hit arrow
    public static int StaminaGain { get; set; }
    public static int MaxStamina { get; set; }
    public static int MaxHealth { get; set; }
    public static int EnemyHealth { get; set; }
    public static float TimePerBar { get; set; }
    public static int ArrowCount { get; set; }
    public static float BufferTime { get; set; }
    public static Environment Env { get; set; }
    public static int HealthPotionCount {get; set;}
    public static int CoinCount { get; set; }
    public static int CoinsToDrop {get; set; }
    // Set to -1 for tutorial, 0 for normal, 1 for boss
    public static int FightType {get; set;}
}
