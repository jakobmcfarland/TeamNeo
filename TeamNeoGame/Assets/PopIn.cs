using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopIn : MonoBehaviour
{
    public float time;
    public float timer = 0;
    public GameObject to;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {
            to.SetActive(true);
        }
    }
}
