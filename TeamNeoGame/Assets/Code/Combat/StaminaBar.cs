using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    private Image img;
    private float timer = 1;
    private float percent = 0;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        UpdateStamina(percent);
    }
    void Update ()
    {
        if (timer < 1)
        {
            timer += Time.deltaTime;
            img.fillAmount = Mathf.Lerp(img.fillAmount, percent, timer);
        }
    }
    void UpdateStamina(float nper)
    {
        percent = nper;
        timer = 0;
    }
}
