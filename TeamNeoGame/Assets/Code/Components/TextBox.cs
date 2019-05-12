using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextBox
{
	public (string, float) [] dialogue;
	private float timer;
	void New() {

	}
    // Start is c alled before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class TBox: MonoBehaviour {
	public string [] dialogue;
	public float timePerBox = 2.0f;
	private int index = 0;
	public KeyCode nextKey;
	private TextMeshProUGUI textBox;
	private SpriteRenderer textSprite;
    private bool done;
    private float timer;
	void Start() {
		textBox = GetComponent<TextMeshProUGUI>();
		textSprite.enabled = enabled;
	}
	void Update() {
        if (Input.GetKeyDown(nextKey))
        {
            if (!done)
            {
                done = true;
                textBox.text = dialogue[index];
            }
            else
            {
                index++;
                done = false;
            }
        }
        if (!done)
        {
            if (textBox.text.Length == dialogue[index].Length)
            {
                done = true;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                textBox.text += dialogue[index][textBox.text.Length];
                timer = dialogue[index].Length / timePerBox;
            }
        }
    }
}