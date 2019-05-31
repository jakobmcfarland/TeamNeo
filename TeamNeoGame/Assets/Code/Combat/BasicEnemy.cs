using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BasicEnemy : MonoBehaviour
{
    public CombatManager cm;
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 10;
    public AttackManager attackManager;
    public string ename;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public HPBar hpBar;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    { 
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void SetName(string nam)
    {
        if (anim == null) {
            anim = GetComponent<Animator>();
        }
        ename = nam;
        nameText.text = nam.ToUpper();
        switch(ename) {
            case "Park":
                anim.SetInteger("Enemy", 2);
                break;
            case "Car":
                anim.SetInteger("Enemy", 1);
                break;
            case "Boss":
                anim.SetInteger("Enemy", 3);
                break;
            default:   
                anim.SetInteger("Enemy", 1);
                break;

        }
    }
    public void ModHealth(int mod)
    {
        health += mod;
        healthText.text = health.ToString();
        hpBar.UpdateHP((float)health / (float)maxHealth);

        GetComponent<Animator>().SetBool("Damaged", true);

        if (health <= 0)
        {
            print("Victory!");
            if (CombatInfo.FightType != -1) {
            CombatInfo.CombatsFinished++;
        }
        if(CombatInfo.FightType == -1) {
            CombatInfo.FightType = 0;
        }
            SaveGameManager.SaveGame(new Vector3(0, 0, 0), CombatInfo.CombatsFinished);
            GameState.curHealth = cm.player.health;
            CombatInfo.CoinCount+= CombatInfo.CoinsToDrop;
            if (CombatInfo.FightType == 1) {

                SceneManager.LoadScene("Credits");
            } else {
               SceneManager.LoadScene("Map");
            }
        }
    }
}
