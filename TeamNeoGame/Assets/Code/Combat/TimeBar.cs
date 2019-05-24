using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeBar : MonoBehaviour
{
    private Image img;
    public float percent = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        img.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void UpdateTime(float newPercent)
    {
        percent = newPercent;
        img.fillAmount = percent;
    }
}
