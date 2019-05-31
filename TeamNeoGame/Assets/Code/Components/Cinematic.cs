using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cinematic : MonoBehaviour
{
    public float time = 2.0f;
    private float timer = 0;
    private SpriteRenderer sprite;
    private Sprite[] frames;
    private int index = -1;
    public float offset = 1;
    private float offsetTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        frames = Resources.LoadAll<Sprite>("Cinematic");

    }
    void End() {
        SetTutorialSettings();
        SceneManager.LoadScene("Combat");  
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) { 
            End();
        }
        offsetTimer += Time.deltaTime;
        if (offsetTimer >= offset) {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = time;
            index++;
            if (index >= frames.Length)
            {
                End();
            }
            else
            {
                sprite.sprite = frames[index];
            }
        }
            }
    }
    void SetTutorialSettings() {
        CombatInfo.MaxHealth = 100;
        CombatInfo.EnemyDamage = 1;
        CombatInfo.EnemyHealth = 100;
        CombatInfo.PlayerDamage = 50;
        CombatInfo.TimePerBar = 10;
        CombatInfo.Env = Environment.City;
        CombatInfo.FightType = -1;
        CombatInfo.ArrowCount = 3;
        CombatInfo.EnemyName = "tutorial dude";
        CombatInfo.EnemySprite= Resources.Load<Sprite>("EnemyBattle1");
        CombatInfo.StaminaGain = 19;
        CombatInfo.MaxStamina = 60;
        CombatInfo.BufferTime = 0;
        CombatInfo.CoinsToDrop = 1;
        CombatInfo.HealthPotionCount = 3;
        CombatInfo.TutorialText = true;
    }
}
