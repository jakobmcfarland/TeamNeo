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
            switch (selected)
            {
                //  New Game
                case 0:
                    CombatInfo.HealthPotionCount = 3;
                    GameState.curHealth = 100;
                    GameState.Player = new Vector3(-22, -24.5f, 0);
                    SceneManager.LoadScene("Cinematic");
                    break;
                //  Load Game
                case 1:
                    bool state = SaveGameManager.LoadGame();
                    if(state)
                        SceneManager.LoadScene("Map");
                    break;
                //  Credits
                case 2:
                    SceneManager.LoadScene("Credits");
                    break;
                //  Quit Game
                case 3:
                    Application.Quit();
                    break;
                //  WTF?
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
