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
    public Element[] attacking;
    public AttackBox[] attackBoxes;
    public GameObject attackGroup;
    public int attackCount = 4;
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
    }
    void FillAttacks()
    {
        for(var i = 0; i < attackCount; i++)
        {
            attacking[i] = PickAttack();
        }
    }
    // Update is called once per frame
    void Update()
    {

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
