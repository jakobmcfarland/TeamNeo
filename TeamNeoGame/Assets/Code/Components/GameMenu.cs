﻿/******************************************************************************
    Game Menu
    William Siauw
    This script controls the navigation of the menu
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public TextMeshProUGUI[] options;
    public GameObject Player;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode pickKey;
    public int selected = 0;
    public bool store = false;
    // Start is called before the first frame update
    void Start()
    {
        options = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(downKey))
        {
            if (selected == options.Length - 1)
            {
                selected = 0;
            }
            else
            {
                selected++;
            }
        }
        else if (Input.GetKeyDown(upKey))
        {
            if (selected == 0)
            {
                selected = options.Length - 1;
            }
            else
            {
                selected--;
            }
        }
        if (Input.GetKeyDown(pickKey))
        {
            if (store)
            {
                switch(selected)
                {
                    case 0:
                        CombatInfo.HealthPotionCount++;
                        print("get potion");
                        break;
                    case 1:
                        transform.parent.gameObject.SetActive(false);
                        break;
                }
            }
            else
            {
                switch (selected)
                {
                    case 0:
                        SaveGameManager.SaveGame(Player.transform.position, CombatInfo.CombatsFinished);
                        break;
                    case 1:
                        print("use potion");
                        break;
                    case 2:
                        Application.Quit();
                        break;
                }
            }
        }
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selected)
            {
                options[i].enabled = true;
            }
            else
            {
                options[i].enabled = false;
            }
        }
    }
}
