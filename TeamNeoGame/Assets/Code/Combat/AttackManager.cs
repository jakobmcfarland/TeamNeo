using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public int attackCount = 4;
    public int right = 0;
    public int hit = 0;
    public AttackBox[] attacks;
    public PlayerCombat player;
    public float time = 5.0f;
    private float timer = 0;
    public KeyCode greenKey;
    public KeyCode redKey;
    public KeyCode tanKey;
    public KeyCode blueKey;
    public int hpWrong = 10;
    public int staminaRight = 10;
    public TimeBar timeBar;
    public float bufferTime = 1.0f;
    private float bTimer = 0;
    public bool buffer = false;
    public void Begin()
    {
        attacks = this.gameObject.GetComponentsInChildren<AttackBox>();
        timer = time;
        hit = 0;
        right = 0;
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
        for (int i = hit; i < attackCount; i++)
        {
            print(i);
            attacks[i].SetDone(false);
            TryE(false);
        }
        timer = time;
        bTimer = bufferTime;
        buffer = true;
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
        }
        else
        {
            player.ModHealth(-hpWrong);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (buffer)
        {
            bTimer -= Time.deltaTime;
            if (bTimer <= 0 && player.stamina <= player.maxStamina)
            {
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
                if (Input.GetKeyDown(blueKey))
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
                else if (Input.GetKeyDown(greenKey))
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
                else if (Input.GetKeyDown(redKey))
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
                else if (Input.GetKeyDown(tanKey))
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
