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
    public float startTime = 2;
    private float startTimer = 0;
    public float startAnimTime = 1;
    public Animation[] startAnimations;
    public Animator[] startAnimators;
    private float startAnimTimer = 0;
    public bool paused = false;
    public Animator spaceAnim;
    public Animator slashAnim;
    public int[] tuts = {0,0,0,0,0,0};
    public FMODUnity.StudioEventEmitter hurtSound;
    // Start is called before the first frame update

    public void Pause(bool p){
        paused = p;
        am.paused = p;
    }
    // Update is called once per frame
    void Update()
    {
        if (!paused) {
        if (startTimer >= 0){
        startTimer += Time.deltaTime;
    }
        startAnimTimer += Time.deltaTime;
        if (startAnimTimer >= startAnimTime && startAnimTimer >= 0)
        {
            for (int i = 0; i< startAnimations.Length; i++)
            {
                startAnimations[i].enabled = true;
            }
            for (int i = 0; i< startAnimators.Length; i++)
            {
                startAnimators[i].enabled = true;
            }
        }
        if (startTimer >= startTime && startTimer >= 0)
        {
            if (CombatInfo.FightType == -1 && tuts[0] == 0) {
                print("tut1");
                tuts[0] = 1;
                string[] text = {"press space to advance","hit the arrows using arrow keys", "before the timer runs out"};
                TextBox.DisplayText(text , 4);
                Pause(true);
            } else {
                StartCombat();
                startTimer = -1;
            }
        }
    }
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
        CombatInfo.Env = Environment.City;
        CombatInfo.CoinsToDrop = 2;
        CombatInfo.HealthPotionCount = 3;
        CombatInfo.FightType = 0;
        //CombatInfo.Tutorial = false;
    }
    void StartCombat()
    {
        print("start combat");
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
        player.healthCount = CombatInfo.HealthPotionCount;
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
        //hurtSound.Play();
        slashAnim.SetTrigger("Slash");
        spaceAnim.SetTrigger("Pressed");
        enemy.ModHealth((int)(-damage * Mathf.Pow(am.damageScale, (float)am.streak)));
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
