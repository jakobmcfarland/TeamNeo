/******************************
 * Author: Nico
 * Date Last Edited: 5-30-2019
 * Description: A text box used for dialogue
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueBox : MonoBehaviour
{
    public string[] dialogue;
    public float timePerBox = 2.0f;
    private int index = 0;
    public KeyCode nextKey;
    private TextMeshProUGUI textBox;
    public SpriteRenderer textSprite;
    public Image textImage;
    public bool done;
    public float timer;
    private FMODUnity.StudioEventEmitter dialogueSound;
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        dialogueSound = GameObject.Find("TextSound").GetComponent<FMODUnity.StudioEventEmitter>();
        print(dialogueSound);
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
                if(textSprite != null) {
                    textSprite.enabled = false;

                }
                if (textImage != null) {
                                    textImage.enabled = false;

                }
                    textBox.enabled = false;
                    enabled = false;  
                }
                done = false;
                textBox.text = "";
            }
        }
        if (!done)
        {
            if (dialogue.Length == 0) {
                done = true;
                if(textSprite == null) {
                    textImage.enabled = false;
                } else {
                    textSprite.enabled = false;
                }
                    textBox.enabled = false;
                    enabled = false;       
            } else {
            if (textBox.text.Length >= dialogue[index].Length)
            {
                done = true;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                dialogueSound.Play();
                textBox.text += dialogue[index][textBox.text.Length].ToString().ToUpper();
                timer = timePerBox / dialogue[index].Length;
            }
        }
        } else if (done) {
            dialogueSound.Stop();
        }
    }
}
