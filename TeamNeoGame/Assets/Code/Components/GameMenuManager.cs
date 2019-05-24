/******************************************************************************
    Game Menu Manager
    William Siauw
    This script controls the activation and deactivation of the in game menu.
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public KeyCode enableKey;
    public GameObject menuObj;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        menuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(enableKey))
        {
            menuObj.SetActive(!menuObj.activeSelf);
        }

        if (menuObj.activeSelf)
        {
            player.GetComponent<MapPlayerController>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<Animator>().Play("Idle");
        }
        else
            player.GetComponent<MapPlayerController>().enabled = true;
    }
}
