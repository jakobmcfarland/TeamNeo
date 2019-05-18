using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public bool done = false;
    public bool success = false;
    public Element element;
    private SpriteRenderer sprite;
    public SpriteRenderer fill;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hide()
    {
        fill.enabled = false;
        sprite.enabled = false;
    }
    public void Show()
    {
        fill.enabled = true;
        sprite.enabled = true;
    }
    public void SetElement(Element el)
    {
        element = el;
        fill.color = Color.white;
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Rotate(0,0,el.ToDegrees() + 90);
    }
    public void SetDone(bool done)
    {
        this.done = true;
        success = done;
        if (success)
        {
            fill.color = Color.green;
        }
        else
        {
            fill.color = Color.red;
        }
    }
}
