using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatusText : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float time = 1.0f;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && text.text != "")
        {
            text.text = "";
        }
    }
    public void Display(string msg)
    {
        timer = time;
        text.text = msg;
    }
}
