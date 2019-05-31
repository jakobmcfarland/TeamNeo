using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PotionCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CombatInfo.HealthPotionCount != coins)
        {
            coins = CombatInfo.HealthPotionCount;
            coinText.text = coins.ToString();
        }
    }
}
