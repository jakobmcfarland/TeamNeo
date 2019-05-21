using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public string EnemyName = "Enemy";
    public Sprite EnemySprite;
    public int PlayerDamage = 50;
    public int EnemyDamage = 10;
    public int StaminaGain = 10;
    public int MaxStamina = 100;
    public int MaxHealth = 100;
    public int EnemyHealth = 100;
    public float TimePerBar = 5.0f;
    public int ArrowCount = 6;
    public float BufferTimer = 0.1f;
    public void LoadCombat()
    {
        CombatInfo.EnemyName = EnemyName;
        CombatInfo.EnemySprite = EnemySprite;
        CombatInfo.PlayerDamage = PlayerDamage;
        CombatInfo.EnemyDamage = EnemyDamage;
        CombatInfo.StaminaGain = StaminaGain;
        CombatInfo.MaxStamina = MaxStamina;
        CombatInfo.MaxHealth = MaxHealth;
        CombatInfo.EnemyHealth = EnemyHealth;
        CombatInfo.TimePerBar = TimePerBar;
        CombatInfo.ArrowCount = ArrowCount;
        CombatInfo.BufferTime = BufferTimer;
    }
}
