using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCombat : MonoBehaviour
{
    public KeyCode greenKey;
    public KeyCode redKey;
    public KeyCode tanKey;
    public KeyCode blueKey;
    public KeyCode attackKey;
    public CombatManager cm;
    public int health = 100;
    public int maxHealth = 100;
    public int stamina = 0;
    public int maxStamina = 100;
    public int staminaCost = 20;
    public int staminaGain = 10;
    public Element attacking;
    public float attackTime = 1.0f;
    private float attackTimer = 0.0f;
    private bool at = false;
    public int damage = 50;
    public float critMod = 3.0f;
    public HPBar hpBar;
    public HPBar staminaBar;
    public TextMeshProUGUI healthText;
    public Image staminaGauge;
    private Animator staminaAnim;
    public AttackManager attackManager;
    public int healthCount = 3;
    public TextMeshProUGUI hpPotionText;
    public float healPerPotion = 0.5f;
    public KeyCode healKey;

    // Start is called before the first frame update
    void Start()
    {
        staminaAnim = staminaGauge.GetComponent<Animator>();
        hpPotionText.text = healthCount.ToString();
        //health = GameState.curHealth;
        Debug.Log(GameState.curHealth);
        Debug.Log("Health: " + health);
      //  ModHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(attackKey) && stamina >= maxStamina)
        {
            ModStamina(-stamina);
            cm.AttackEnemy(damage);
        }
        if (staminaGauge.fillAmount >= 1 && attackManager.buffer)
        {
            //staminaAnim.SetBool("Flash", true);
        }
        else
        {
            //staminaAnim.SetBool("Flash", false);
        }
        if (healthCount > 0 && Input.GetKeyDown(healKey)) {
            UsePotion();
        }

    }
    public void Accelerate()
    {

    }
    public void ModHealth(int mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.text = health.ToString();
        hpBar.UpdateHP((float)health / (float)maxHealth);
        if (health <= 0)
        {
            print("Loss!");
            SceneManager.LoadScene("GameOver");
        }
    }
    public void ModStamina(int mod)
    {
        stamina += mod;
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        staminaGauge.fillAmount = (float)stamina / (float)maxStamina;
    }
    public void UsePotion() {
        healthCount--;
        CombatInfo.HealthPotionCount--;
        ModHealth((int)(healPerPotion * (float)maxHealth));
        hpPotionText.text = healthCount.ToString();
    }
}