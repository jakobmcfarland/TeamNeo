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
    public CombatManager cm;
    public int health = 100;
    public Element attacking;
    public float attackTime = 1.0f;
    private float attackTimer = 0.0f;
    private bool at = false;
    public int damage = 10;
    public float critMod = 3.0f;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
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
                    if (attacking.Beats(cm.enemy.attacking) == 1)
                    {
                        cm.Counter();
                    }
                    else
                    {
                        cm.Accelerate();
                    }
                }
                else
                {
                    cm.Accelerate();
                }
            }
        }
    }
    public void Accelerate()
    {

    }
    public void ModHealth(int mod)
    {
        health += mod;
        healthText.text = health.ToString();
    }
}
