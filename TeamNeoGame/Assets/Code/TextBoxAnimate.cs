using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextBoxAnimate : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float animTime = 1;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0 && text.enabled == false)
        {
            text.enabled = true;
        }
    }
}
