using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cinematic : MonoBehaviour
{
    public float time = 2.0f;
    private float timer = 0;
    private SpriteRenderer sprite;
    private Sprite[] frames;
    private int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        frames = Resources.LoadAll<Sprite>("Cinematic");

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = time;
            index++;
            if (index >= frames.Length)
            {
                SceneManager.LoadScene("Map");
            }
            else
            {
                sprite.sprite = frames[index];
            }
        }
    }
}
