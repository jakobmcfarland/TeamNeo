using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeOut : MonoBehaviour
{
    public float fadeTime = 0.70f;
    private float timer = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != -1)
        {
            timer += Time.deltaTime;
            if (timer >= fadeTime)
            {
                SceneManager.LoadScene("Combat");

            }
        }

    }
    public void Fade()
    {
        GetComponent<Animator>().enabled = true;
        timer = 0;
    }
}
