using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    int count;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  Check if the user has entered the right combo
        if (Input.GetKeyDown(KeyCode.V))
            if (count == 0)
                count++;
        if (Input.GetKeyDown(KeyCode.I))
            if (count == 1)
                count++;
        if (Input.GetKeyDown(KeyCode.P))
            if (count == 2)
                count++;
        if (Input.GetKeyDown(KeyCode.E))
            if (count == 3)
                count++;
        if (Input.GetKeyDown(KeyCode.R))
            if (count == 4)
            {
                Debug.Log("cheatz");
                activated = !activated;
                count = 0;
            }
        if (activated)
        {

        }
        
    }
}
