using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBox : MonoBehaviour
{
    public string[] dialogue;
    public float timePerBox = 2.0f;
    private int index = 0;
    public KeyCode nextKey;
    private TextMeshProUGUI textBox;
    public SpriteRenderer textSprite;
    public bool done;
    public float timer;
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        textSprite.enabled = enabled;
    }
    void Update()
    {
        if (Input.GetKeyDown(nextKey))
        {
            if (!done)
            {
                done = true;
                textBox.text = dialogue[index].ToUpper();
            }
            else
            {
                index++;
                if (index >= dialogue.Length)
                {
                    MapPlayerController mapPlayer = FindObjectOfType<MapPlayerController>();
                    if (mapPlayer != null)
                    {
                        mapPlayer.paused = false;
                    }
                    CombatManager cm = FindObjectOfType<CombatManager>();
                    if (cm != null) {
                        cm.Pause(false);
                    }
                    textBox.enabled = false;
                    textSprite.enabled = false;
                    enabled = false;
                }
                done = false;
                textBox.text = "";
            }
        }
        if (!done)
        {
            if (textBox.text.Length >= dialogue[index].Length)
            {
                done = true;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                textBox.text += dialogue[index][textBox.text.Length].ToString().ToUpper();
                timer = timePerBox / dialogue[index].Length;
            }
        }
    }
}
