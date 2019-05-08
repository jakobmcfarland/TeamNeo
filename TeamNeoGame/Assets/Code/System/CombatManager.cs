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
        CombatInfo.EnemyName = "swamp man";
        CombatInfo.EnemySprite = Resources.Load<Sprite>("Enemy");
        CombatInfo.PlayerDamage = 50;
        CombatInfo.EnemyDamage = 10;
        CombatInfo.StaminaGain = 10;
        CombatInfo.MaxStamina = 100;
        CombatInfo.MaxHealth = 100;
        CombatInfo.EnemyHealth = 100;
        CombatInfo.TimePerBar = 5.0f;
        CombatInfo.ArrowCount = 4;
        CombatInfo.BufferTime = 1.0f;
    }
    void StartCombat()
    {
        enemy.name = CombatInfo.EnemyName;
        enemy.GetComponent<SpriteRenderer>().sprite = CombatInfo.EnemySprite;
        player.damage = CombatInfo.PlayerDamage;
        enemy.attackManager.hpWrong = CombatInfo.EnemyDamage;
        enemy.attackManager.staminaRight = CombatInfo.StaminaGain;
        player.maxStamina = CombatInfo.MaxStamina;
        player.maxHealth = CombatInfo.MaxHealth;
        enemy.maxHealth = CombatInfo.EnemyHealth;
        enemy.attackManager.time = CombatInfo.TimePerBar;
        enemy.attackManager.attackCount = CombatInfo.ArrowCount;
        enemy.attackManager.bufferTime = CombatInfo.BufferTime;
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
        /*if (enemy.attacking == player.attacking)
        {
            print("Blocked!");
            //Blocked
            player.ModHealth(-(int)(0.1f * enemy.damage));
            player.ModStamina(player.staminaGain);
        }
        else
        {
            print("Not Blocked!");
            print(enemy.attacking);
            print(player.attacking);
            player.ModHealth(-enemy.damage);
            print(player.health);
        }
        enemy.stanceAnim.SetBool("CanCounter", false);*/
    }
    public void Counter()
    {
        print("Countered!");
        enemy.ModHealth( -(int)(player.damage * player.critMod));
        print(enemy.health);
    }
}
