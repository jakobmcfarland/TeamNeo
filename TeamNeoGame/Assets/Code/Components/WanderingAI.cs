using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float FinalTimer = 0;
    public Vector2 End;
    Vector2 Start = FindStart();
    float Distance;
    //a^2 +b^2 = c^2
    float timer = 0;
    // True means moving towards End, False means moving away from End
    bool direction = true;
    // speed = distance/time
    // v = d/t
    void Update()
    {
        if (timer >= FinalTimer)
            direction = !direction;
        //flip direction if we have past the max time
        float Distance = ((Start.x - End.x) * (Start.x - End.x)) + ((Start.y - End.y) * (Start.y - End.y));
        Distance = Math.Sqrt(Distance);
        timer += Time.deltaTime;
        
    }
    void FindStart() {
        Start = transform;
    }
}