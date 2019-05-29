/******************************************************************************
    Cheat Code Manager
    William Siauw
    This script contains the code for managing the cheat codes, from enabling / disabling, to the actual cheats them selves
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Code.Map;
public class CheatCodeManager : MonoBehaviour
{
    int count;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Check if the user has entered the right combo
        if (Input.GetKeyDown(KeyCode.V))
            if (count == 0)
                count++;
        if (Input.GetKeyDown(KeyCode.I))
            if (count == 1)
                count++;
        if (Input.GetKeyDown(KeyCode.P))
            if (count == 2)
                count++;
        if (Input.GetKeyDown(KeyCode.E))
            if (count == 3)
                count++;
        if (Input.GetKeyDown(KeyCode.R))
            if (count == 4)
            {
                if (activated)
                    Debug.Log("cheat deactivated");
                else
                    Debug.Log("cheat activated");
                activated = !activated;
                count = 0;
            }
        if (activated)
        {
            //  Skip to Boss
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (MapNodeList.nodes.Count == 3)
                {
                    MapNodeList.nodes[0].nodeState = NodeState.Complete;
                    MapNodeList.nodes[1].nodeState = NodeState.Current;
                    Debug.Log("Skip to Boss Cheat");

                    //  If we are already on the map, save and then load the scene to have the nodes update visually
                    if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map"))
                    {
                        SaveGameManager.SaveGame(GameState.Player, CombatInfo.CombatsFinished);
                        SaveGameManager.LoadGame();
                        SceneManager.LoadScene("Map");
                    }
                }
                else
                    Debug.LogError("MAP NODES NOT INITIALIZED. THERE ARE NOT 3 MAP NODES IN THE LIST");
            }

            //  Win Current Combat
            if (Input.GetKeyDown(KeyCode.F3))
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Combat"))
                {
                    CombatManager cm = FindObjectOfType<CombatManager>();
                    cm.AttackEnemy(cm.enemy.maxHealth);
                    Debug.Log("Finished Combat Cheat");
                }

            //  Heal Player to Full
            if (Input.GetKeyDown(KeyCode.F4))
            {
                
                Debug.Log("Heal Cheat");
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Combat"))
                {
                    CombatManager cm = FindObjectOfType<CombatManager>();
                    cm.player.ModHealth(GameState.GetInstance().MaxHealth);
                }
                else
                    GameState.curHealth = GameState.GetInstance().MaxHealth;
            }
        }
        
    }
}
