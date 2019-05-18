using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public string EnemyName = "Enemy";
    public Sprite EnemySprite = Resources.Load<Sprite>("Enemy");
    public static int PlayerDamage = 50;
    public static int EnemyDamage = 10;
    public static int StaminaGain = 10;
    public static int MaxStamina = 100;
    public static int MaxHealth = 100;
    public static int EnemyHealth = 100;
    public static float TimePerBar = 5.0f;
    public static int ArrowCount = 6;
    public static float BufferTimer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LoadCombat()
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
