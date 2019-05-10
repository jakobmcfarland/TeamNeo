using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerCombat player;
    public BasicEnemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        SetDefaultParameters();
        StartCombat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDefaultParameters() {
        CombatInfo.CombatInfo combatInfo = CombatInfo.CurrentCombatInfo.CombatInfo;
        combatInfo.EnemyName = "swamp man";
        combatInfo.EnemySprite = Resources.Load<Sprite>("Enemy");
        combatInfo.PlayerDamage = 50;
        combatInfo.EnemyDamage = 10;
        combatInfo.StaminaGain = 10;
        combatInfo.MaxStamina = 100;
        combatInfo.MaxHealth = 100;
        combatInfo.EnemyHealth = 100;
        combatInfo.TimePerBar = 5.0f;
        combatInfo.ArrowCount = 4;
        combatInfo.BufferTime = 1.0f;
    }
    void StartCombat()
    {
        CombatInfo.CombatInfo combatInfo = CombatInfo.CurrentCombatInfo.CombatInfo;
        enemy.name = combatInfo.EnemyName;
        enemy.GetComponent<SpriteRenderer>().sprite = combatInfo.EnemySprite;
        player.damage = combatInfo.PlayerDamage;
        enemy.attackManager.hpWrong = combatInfo.EnemyDamage;
        enemy.attackManager.staminaRight = combatInfo.StaminaGain;
        player.maxStamina = combatInfo.MaxStamina;
        player.maxHealth = combatInfo.MaxHealth;
        enemy.maxHealth = combatInfo.EnemyHealth;
        enemy.attackManager.time = combatInfo.TimePerBar;
        enemy.attackManager.attackCount = combatInfo.ArrowCount;
        enemy.attackManager.bufferTime = combatInfo.BufferTime;
        player.enabled = true;
        enemy.enabled = true;
    }
    public void Accelerate()
    {
        //enemy.Accelerate();
    }
    public void AttackEnemy(int damage) {
        enemy.ModHealth(-damage);
    }
    public void HurtPlayer(int damage)
    {
        player.ModHealth(-damage);
        print(player.health);
    }
    public void Clash()
    {
    }
    public void Counter()
    {
        print("Countered!");
        enemy.ModHealth( -(int)(player.damage * player.critMod));
        print(enemy.health);
    }
}
