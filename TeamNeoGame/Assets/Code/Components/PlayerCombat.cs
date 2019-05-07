using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public int damage = 10;
    public float critMod = 3.0f;
    public HPBar hpBar;
    public HPBar staminaBar;
    public TextMeshProUGUI healthText;
    public StatusText st;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if(Input.GetKeyDown(attackKey) && stamina >= maxStamina) {
            ModStamina(-stamina);
            cm.AttackEnemy(damage);
        }
        /*if (attackTimer <= 0)
        {
            if (Input.GetKeyDown(blueKey))
            {
                attacking = Element.Water;
                attackTimer = attackTime;
            }
            else if (Input.GetKeyDown(greenKey))
            {
                attacking = Element.Grass;
                attackTimer = attackTime;

            }
            else if (Input.GetKeyDown(redKey))
            {
                attacking = Element.Fire;
                attackTimer = attackTime;

            }
            else if (Input.GetKeyDown(tanKey))
            {
                attacking = Element.Tan;
                attackTimer = attackTime;

            }
            if (cm.enemy.isAttacking && Input.GetKeyDown(blueKey) || Input.GetKeyDown(greenKey) || Input.GetKeyDown(redKey) || Input.GetKeyDown(tanKey))
            {
                if (cm.enemy.canCounter)
                {
                    if (attacking.Beats(cm.enemy.attacking) == 1 && stamina >= staminaCost)
                    {
                        st.Display("Countering!"); 
                        ModStamina(-staminaCost);
                        cm.Counter();
                    }
                    else
                    {
                        st.Display("Trying to Block!");
                        cm.Accelerate();
                    }
                }
                else
                {
                    st.Display("Trying to Block!");

                    cm.Accelerate();
                }
            }
        }*/
    }
    public void Accelerate()
    {

    }
    public void ModHealth(int mod)
    {
        health += mod;
        healthText.text = health.ToString();
        hpBar.UpdateHP((float)health / (float)maxHealth);
    }
    public void ModStamina(int mod) {
        stamina += mod;
        staminaBar.UpdateHP((float)stamina / (float)maxStamina);
    }
}
