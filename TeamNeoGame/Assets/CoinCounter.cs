using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
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
        if (CombatInfo.CoinCount != coins)
        {
            coins = CombatInfo.CoinCount;
            coinText.text = coins.ToString();
        }
    }
}
