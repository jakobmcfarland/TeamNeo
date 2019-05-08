using System.Collections;
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
        sprite.color = Color.white;
        //sprite.color = el.ToColor();
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Rotate(0,0,el.ToDegrees());
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
