using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public bool done = false;
    public bool success = false;
    public Element element;
    private SpriteRenderer sprite;
    private Animator anim;
    public Sprite doneS;
    public Sprite wait;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hide()
    {
        sprite.enabled = false;
    }
    public void Show()
    {
        sprite.enabled = true;
    }
    public void SetElement(Element el)
    {
        element = el;
        print(anim);
        anim.SetInteger("State", 0);
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Rotate(0, 0, el.ToDegrees() + 90);
    }
    public void SetDone(bool done)
    {
        this.done = true;
        success = done;
        if (success)
        {
        anim.SetInteger("State", 1);
        }
        else
        {
        anim.SetInteger("State", 2);
        }
    }
}
