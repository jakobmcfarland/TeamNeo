using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    public float mapPlayerWalkSpeed = 15.0f;
    public float mapPlayerMaxSpeed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0.0f, 0.0f);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized * mapPlayerWalkSpeed;

        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
