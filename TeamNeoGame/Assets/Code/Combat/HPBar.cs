using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    private SpriteRenderer sprite;
    public float maxSize = 3.743f;
    public bool useGradient = true;
    private Gradient gradient;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;
    private float timer = 1.0f;
    private float percent = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.transform.localScale = new Vector3(maxSize, 0.5f, 1);
        gradient = new Gradient();
        colorKey = new GradientColorKey[3];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.yellow;
        colorKey[1].time = 0.5f;
        colorKey[2].color = Color.green;
        colorKey[2].time = 1.0f;
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;
        gradient.SetKeys(colorKey, alphaKey);
        UpdateHP(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 1.0f) {
            timer += Time.deltaTime;
            var lerp = Mathf.Lerp(sprite.transform.localScale.x / maxSize, percent, timer);
            sprite.transform.localScale = new Vector3(lerp * maxSize, 0.5f, 1);
            if (useGradient) {
                sprite.color = gradient.Evaluate(lerp);
            }
        }   
    }
    public void UpdateHP(float newPercent)
    {
        percent = newPercent;
        timer = 0;
    }
}
