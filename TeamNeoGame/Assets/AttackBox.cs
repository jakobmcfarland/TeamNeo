﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public bool done = false;
    public bool success = false;
    public Element element;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetElement(Element el)
    {
        element = el;
        sprite.color = el.ToColor();
    }
    public void SetDone(bool done)
    {
        this.done = true;
        success = done;
        if (success)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.red;
        }
    }
}
