using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AttackManager : MonoBehaviour
{
    public int attackCount = 4;
    public int right = 0;
    public int hit = 0;
    public AttackBox[] attacks;
    public PlayerCombat player;
    public CombatManager cm;
    public float time = 5.0f;
    private float timer = 0;
    public KeyCode greenKey;
    public KeyCode redKey;
    public KeyCode tanKey;
    public KeyCode blueKey;
    public KeyCode greenKey2;
    public KeyCode redKey2;
    public KeyCode tanKey2;
    public KeyCode blueKey2;
    public int hpWrong = 10;
    public int staminaRight = 10;
    public TimeBar timeBar;
    public float bufferTime = 1.0f;
    private float bTimer = 0;
    public bool buffer = false;
    public int streak = 0;
    public float damageScale = 1.01f;
    public TextMeshProUGUI streakText;
    public SpriteRenderer spaceSprite;
    public bool paused = false;
    public void Begin()
    {
        print("begin");
        attacks = this.gameObject.GetComponentsInChildren<AttackBox>();
        timer = time;
        hit = 0;
        right = 0;
        spaceSprite.enabled = false;
        for (int i = 0; i < attackCount; i++)
        {
            attacks[i].done = false;
            attacks[i].success = false;
            attacks[i].SetElement(PickAttack());
            attacks[i].Show();
        }
        for (int i = attackCount; i < attacks.Length; i++)
        {
            attacks[i].Hide();
        }
    }
    public void Finish()
    {
        if (CombatInfo.FightType == -1 && cm.tuts[1] ==0 && cm.tuts[0] == 1) {
            cm.tuts[1]  = 1;
            cm.Pause(true);
            string[] d = {"correctly hit arrows increase your stamina"};
            TextBox.DisplayText(d, 5,true);
        } else if (CombatInfo.FightType == -1 && cm.tuts[2] ==0 && cm.tuts[1] == 1) {
            cm.tuts[2]  = 1;
            cm.Pause(true);
            string[] d = {"when stamina is full hit space to attack"};
            TextBox.DisplayText(d, 5,true);     
        }
        for (int i = hit; i < attackCount; i++)
        {
            attacks[i].SetDone(false);
            TryE(false);
        }
        timer = time;
        bTimer = bufferTime;
        buffer = true;
        if(player.stamina >=player.maxStamina) {
            spaceSprite.enabled = true;
            for(int i = 0; i < attackCount; i++) {
                attacks[i].Hide();   
            }
        }
    }
    Element PickAttack()
    {
        float rand = Random.value;
        if (rand <= 0.25f)
        {
            return Element.Tan;
        }
        else if (rand <= 0.5f)
        {
            return Element.Water;
        }
        else if (rand <= 0.75f)
        {
            return Element.Grass;
        }
        else
        {
            return Element.Fire;
        }
    }
    void TryE(bool r)
    {
        if (r)
        {
            player.ModStamina(staminaRight);
            streak++;
        }
        else
        {
            streak = 0;
            player.ModHealth(-hpWrong);
        }
        streakText.text = "x"+streak.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (!paused){

        if (buffer)
        {
            bTimer -= Time.deltaTime;
            if (bTimer <= 0 && player.stamina < player.maxStamina)
            {
                print("run");
                buffer = false;
                Begin();
            }
        }

        timeBar.UpdateTime(timer / time);
        if (!buffer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Finish();
            }
            if (true)
            {
                if (Input.GetKeyDown(blueKey) || Input.GetKeyDown(blueKey2))
                {
                    if (attacks[hit].element == Element.Water)
                    {
                        TryE(true);

                        attacks[hit].SetDone(true);
                        right++;
                    }
                    else
                    {
                        TryE(false);

                        attacks[hit].SetDone(false);

                    }
                    hit++;
                }
                else if (Input.GetKeyDown(greenKey)|| Input.GetKeyDown(greenKey2))
                {
                    if (attacks[hit].element == Element.Grass)
                    {
                        TryE(true);
                        attacks[hit].SetDone(true);
                        right++;
                    }
                    else
                    {
                        TryE(false);
                        attacks[hit].SetDone(false);

                    }
                    hit++;

                }
                else if (Input.GetKeyDown(redKey)|| Input.GetKeyDown(redKey2))
                {
                    if (attacks[hit].element == Element.Fire)
                    {
                        TryE(true);

                        attacks[hit].SetDone(true);
                        right++;
                    }
                    else
                    {
                        TryE(false);
                        attacks[hit].SetDone(false);

                    }
                    hit++;

                }
                else if (Input.GetKeyDown(tanKey)|| Input.GetKeyDown(tanKey2))
                {
                    if (attacks[hit].element == Element.Tan)
                    {
                        TryE(true);

                        attacks[hit].SetDone(true);
                        right++;
                    }
                    else
                    {
                        TryE(false);
                        attacks[hit].SetDone(false);

                    }
                    hit++;

                }
            }
            if (hit == attackCount)
            {
                Finish();
            }
        }
    }
    }
}
