using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TitlePick : MonoBehaviour
{
    private TextMeshProUGUI titleText;
    // Start is called before the first frame update
    void Start()
    {
        titleText = GetComponent<TextMeshProUGUI>();
        var allTitles = Resources.Load<TextAsset>("titles");
        var listTitles = allTitles.text.Split('\n');
        int index = Random.Range(0, listTitles.Length);
        titleText.text = listTitles[index].ToUpper();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
