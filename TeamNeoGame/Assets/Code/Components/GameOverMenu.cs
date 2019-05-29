/******************************************************************************
    Game Over Menu
    William Siauw
    This script contains the code for the game over menu
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverMenu : MonoBehaviour
{
    public KeyCode reloadKey;
    public KeyCode quitKey;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            SaveGameManager.LoadGame();
            GameState.GetInstance().ReadyToBattle = false;
            SceneManager.LoadScene("Map");
        }
        else if (Input.GetKeyDown(quitKey))
           Application.Quit();
       }
}
