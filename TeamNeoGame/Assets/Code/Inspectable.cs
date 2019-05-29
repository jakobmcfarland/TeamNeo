using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public string[] description;
    public bool inspected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Inspect() {
        if (!inspected)
        {
            MapPlayerController player = FindObjectOfType<MapPlayerController>();
            player.paused = true;
            TextBox.DisplayText(description, 2);
            Debug.Log("ASIUDHASHD");
            inspected = true;
            }
        }
}
