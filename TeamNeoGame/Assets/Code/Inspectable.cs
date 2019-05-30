﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public string[] description;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Inspect() {
        MapPlayerController player = FindObjectOfType<MapPlayerController>();
        player.paused = true;
        TextBox.DisplayText(description, 2, false);
    }
}