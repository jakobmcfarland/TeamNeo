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
    public string name;
    public TextMeshProUGUI healthText;
    public HPBar hpBar;
    // Start is called before the first frame update
    void Start()
    { }
    // Update is called once per frame
    void Update()
    {

    }
    public void ModHealth(int mod)
    {
        health += mod;
        healthText.text = health.ToString();
        hpBar.UpdateHP((float)health / (float)maxHealth);
        if (health <= 0)
        {
            print("Victory!");
            SceneManager.LoadScene("Map");
        }
    }
}
