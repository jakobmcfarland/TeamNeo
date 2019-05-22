﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI[] options;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode pickKey;
    public int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        options = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
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
        else if (Input.GetKeyDown(downKey))
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
            switch (selected)
            {
                case 0:
                    SceneManager.LoadScene("Map");
                    
                    break;
                case 1:
                    Application.Quit();
                    break;
                default:
                    print("This really shouldn't be happening");
                    break;
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
