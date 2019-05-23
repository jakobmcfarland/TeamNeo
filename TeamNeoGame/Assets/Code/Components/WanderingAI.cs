using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float FinalTimer = 0;
    public Vector2 End;
    Vector2 start; // Blake: You can't call a function in the class scope
    float Distance;
    //a^2 +b^2 = c^2
    float timer = 0;
    // True means moving towards End, False means moving away from End
    bool direction = true;
    // speed = distance/time
    // v = d/t
    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        if (timer >= FinalTimer)
            direction = !direction;
        //flip direction if we have past the max time
        float Distance = ((start.x - End.x) * (start.x - End.x)) + ((start.y - End.y) * (start.y - End.y));
        Distance = Mathf.Sqrt(Distance);
        timer += Time.deltaTime;
        
    }
}