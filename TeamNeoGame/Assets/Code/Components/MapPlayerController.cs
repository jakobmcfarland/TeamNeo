using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    public float mapPlayerWalkSpeed = 15.0f;
    public float mapPlayerMaxSpeed = 15.0f;

    Rigidbody2D rigidbody_;
    Animator animator;

    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0.0f, 0.0f);

        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("playerHorizontalSpeed", movement.x);
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("playerVerticalSpeed", movement.y);
        movement = movement.normalized * mapPlayerWalkSpeed;

        rigidbody_.velocity = movement;
    }
}
