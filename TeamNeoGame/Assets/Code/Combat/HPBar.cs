/******************************
 * Author: Nico
 * Description: HP Bar manager
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private Image img;
    public float baseFill = 0.209f;
    public bool useGradient = true;
    private Gradient gradient;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;
    private float timer = 1.0f;
    public float percent = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1.0f)
        {
            timer += Time.deltaTime;
            var lerp = Mathf.Lerp(img.fillAmount, percent, timer);
            img.fillAmount = lerp;
            if (useGradient)
            {
                img.color = gradient.Evaluate(lerp);
            }
        }
    }
    public void UpdateHP(float newPercent)
    {
        percent = newPercent * (1-baseFill) + baseFill;

        if (percent >= 1)
        {
            img.fillAmount = 1;
            timer = 1;
            if (useGradient)
            {
                img.color = gradient.Evaluate(1);
            }
            return;
        }
        timer = 0;
    }
}
