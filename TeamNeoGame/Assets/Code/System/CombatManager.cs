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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartCombat()
    {
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
