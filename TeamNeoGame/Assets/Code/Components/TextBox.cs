﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextBox
{
    public static GameObject prefab;
    public static void DisplayText(string[] dialogue, float time)
    {
        if(prefab == null)
        {
            prefab = Resources.Load<GameObject>("Prefabs/TextBox");
        }
        GameObject text = Object.Instantiate(prefab, Camera.main.transform);
        
        //  text.transform.position = new Vector3(0, -3.5f, -1);
        text.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        Debug.Log(text);
        text.GetComponentInChildren<DialogueBox>(true).dialogue = dialogue;
        text.GetComponentInChildren<DialogueBox>(true).enabled = true;
    }
}
public class TBox : MonoBehaviour
{

}