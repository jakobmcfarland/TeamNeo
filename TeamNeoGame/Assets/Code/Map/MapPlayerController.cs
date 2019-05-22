using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    public float mapPlayerWalkSpeed = 15.0f;
    public float mapPlayerMaxSpeed = 15.0f;

    bool idle;

    Rigidbody2D rigidbody_;
    SpriteRenderer spriteRenderer_;
    Animator animator;

    public Sprite idleForward;
    public Sprite idleSide;
    public Sprite idleBack;

    Sprite currentIdle;

    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentIdle = idleForward;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0.0f, 0.0f);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized * mapPlayerWalkSpeed;

        rigidbody_.velocity = movement;  

        if (movement.x > 0)
        {
            spriteRenderer_.flipX = true;
            currentIdle = idleSide;
            animator.Play("MapPlayerSideAnimation");
        }
        else if (movement.x < 0)
        {
            spriteRenderer_.flipX = false;
            currentIdle = idleSide;
            animator.Play("MapPlayerSideAnimation");
        }
        else
        {
            if (movement.y > 0)
            {
                currentIdle = idleBack;
                animator.Play("MapPlayerBackAnimation");
            }
            else if (movement.y < 0)
            {
                currentIdle = idleForward;
                animator.Play("MapPlayerForwardAnimation");
            }
        }

        //has the player stopped? 
        if ( movement.x == 0 && movement.y == 0 )
        {
            animator.Play("Idle");
            spriteRenderer_.sprite = currentIdle;
            //Debug.Log(spriteRenderer_.sprite);
        }

        if (movement.x != 0 || movement.y != 0)
        {
            GameState.GetInstance().ReadyToBattle = true;
        }
    }
}
