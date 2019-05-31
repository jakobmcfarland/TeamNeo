/******************************
 * Author: Nico
 * Date Last Edited: 5-30-2019
 * Description: Fades the menu out
 ******************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFade : MonoBehaviour
{
	public int to = -1;
	public float time = 1;
	public float timer = -1;
    bool success = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != -1) {
        	timer += Time.deltaTime;
        	if (timer >= time) {
        		switch (to) {
        			                //  New Game
                case 0:
                    CombatInfo.HealthPotionCount = 3;
                    GameState.curHealth = 100;
                    GameState.Player = new Vector3(-22, -29.87f, 0);
                    SceneManager.LoadScene("Cinematic");
                    break;
                //  Load Game
                case 1:
                    bool state = SaveGameManager.LoadGame();
                        if (state)
                            SceneManager.LoadScene("Map");
                        else
                            success = false;
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
        }

    }
    public void FadeTo(int f) {
        if (success)
        {
            timer = 0;
            to = f;
            GetComponent<Animator>().enabled = true;
        }
    }
}
