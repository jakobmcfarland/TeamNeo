using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public PlayerCombat player;
    public BasicEnemy enemy;
    public AttackManager am;
    public SpriteRenderer background;
    public SpriteRenderer platform;
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

    void SetDefaultParameters()
    {
        CombatInfo.EnemyName = "swamp man";
        CombatInfo.EnemySprite = Resources.Load<Sprite>("EnemyBattle1");
        CombatInfo.PlayerDamage = 50;
        CombatInfo.EnemyDamage = 10;
        CombatInfo.StaminaGain = 10;
        CombatInfo.MaxStamina = 100;
        CombatInfo.MaxHealth = 100;
        CombatInfo.EnemyHealth = 100;
        CombatInfo.TimePerBar = 5.0f;
        CombatInfo.ArrowCount = 6;
        CombatInfo.BufferTime = 1.0f;
        CombatInfo.Env = Environment.Grass;
    }
    void StartCombat()
    {
        enemy.SetName(CombatInfo.EnemyName);
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
        SelectEnvironment(CombatInfo.Env);
        player.enabled = true;
        enemy.enabled = true;
        am.Begin();
    }
    public void SelectEnvironment(Environment env)
    {
        platform.sprite = env.PlatformSprite();
        background.sprite = env.BackgroundSprite();
    }
    public void Accelerate()
    {
    }
    public void AttackEnemy(int damage)
    {
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
        enemy.ModHealth(-(int)(player.damage * player.critMod));
        print(enemy.health);
    }
}
