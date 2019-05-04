using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BasicEnemy : MonoBehaviour
{
    public CombatManager cm;
    public SpriteRenderer stance;
    public int health = 100;
    public int maxHealth = 100;
    public float attackTime = 3.0f;
    private float attackTimer = 0.0f;
    public int damage = 10;
    public  Element attacking;
    public bool isAttacking = true;
    public bool canCounter;
    public TextMeshProUGUI healthText;
    public HPBar hpBar;
    public Animator stanceAnim;
    public StatusText st;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackTime;
        attacking = PickAttack();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < 1.0f && attackTimer > 0)
        {
            if (!canCounter)
            {
                st.Display("Can Counter!");
                canCounter = true;
                stanceAnim.SetBool("CanCounter", true);
            }
        }
        else
        {
            canCounter = false;
        }
        if (attackTimer < 0)
        {
            st.Display("Attacking!");
            attackTimer = attackTime;
            Attack();
        }
        if (stance.color != attacking.ToColor())
        {
            stance.color = attacking.ToColor();
        }
    }
    public void Accelerate()
    {
        Attack();
        attackTimer = attackTime;
    }
    void Attack()
    {
        attacking = PickAttack();
        cm.Clash();
    }
    public void ModHealth(int mod)
    {
        health += mod;
        healthText.text = health.ToString();
        hpBar.UpdateHP((float)health / (float)maxHealth);
    }
    Element PickAttack()
    {
        float rand = Random.value;
        if (rand <= 0.25f)
        {
            return Element.Tan;
        } else if (rand <= 0.5f)
        {
            return Element.Water;
        } else if (rand <= 0.75f)
        {
            return Element.Grass;
        }
        else
        {
            return Element.Fire;
        }
    }
}
