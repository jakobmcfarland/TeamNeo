/******************************
 * Author: Nico
 * Date Last Edited: 5-18-2019
 * Description: picks a title
 ******************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
public class TitlePick : MonoBehaviour
{
    public TextMeshProUGUI titleText1;
    public TextMeshProUGUI titleText2;
    // Start is called before the first frame update
    void Start()
    {
        var allTitles = Resources.Load<TextAsset>("titles");
        var listTitles = allTitles.text.Trim().Split('\n');
        int index = Random.Range(0, listTitles.Length);
        string title = listTitles[index].ToUpper().Trim();
        string[] txt = Regex.Split(title, "SAMURAI");
        titleText1.text = txt[0];
        titleText2.text = txt[1];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
