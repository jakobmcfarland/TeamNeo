/******************************************************************************
    Shop Menu Manager
    William Siauw
    This script controls the activation and deactivation of the shop menu
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuManager : MonoBehaviour
{
    public KeyCode enableKey;
    public GameObject menuObj;
    public GameObject player;
    bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        menuObj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            if (Input.GetKeyDown(enableKey))
            {
                menuObj.SetActive(!menuObj.activeSelf);
            }

            if (menuObj.activeSelf || player.GetComponent<MapPlayerController>().storeMenu.activeSelf)
            {
                player.GetComponent<MapPlayerController>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                player.GetComponent<Animator>().Play("Idle");
            }
            else
                player.GetComponent<MapPlayerController>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        colliding = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        colliding = false;
        

    }
}
