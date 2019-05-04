using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float maxSize = 3.743f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.transform.localScale = new Vector3(maxSize, 0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHP(float percent)
    {
        sprite.transform.localScale = new Vector3(percent * maxSize, 0.5f, 1);
    }
}
