using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    public float mapPlayerWalkSpeed = 15.0f;
    public float mapPlayerMaxSpeed = 15.0f;

    Rigidbody2D rigidbody_;
    SpriteRenderer spriteRenderer_;
    Animator animator;

    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0.0f, 0.0f);

        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("playerHorizontalSpeed", Mathf.Abs(movement.x));
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("playerVerticalSpeed", movement.y);
        movement = movement.normalized * mapPlayerWalkSpeed;

        if (movement.y == 0.0f)
        {
            if (movement.x > 0) spriteRenderer_.flipX = true;
            else spriteRenderer_.flipX = false;
        }

        rigidbody_.velocity = movement;
    }
}
