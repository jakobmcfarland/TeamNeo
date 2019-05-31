/******************************************************************************
    Main Menu
    William Siauw
    This script contains the code for the navigation of the main menu
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI[] options;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode pickKey;
    public int selected = 0;
    public FMODUnity.StudioEventEmitter selectSound;
    public FMODUnity.StudioEventEmitter pickSound;
    public MenuFade fade;
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
            selectSound.Play();
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
                        selectSound.Play();

        }
        if (Input.GetKeyDown(pickKey))
        {
            pickSound.Play();
            fade.FadeTo(selected);
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
