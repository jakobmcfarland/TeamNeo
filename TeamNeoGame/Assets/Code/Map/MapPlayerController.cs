

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
    public Sprite idleLeft;
    public Sprite idleRight;
    public Sprite idleBack;
    public GameObject storeMenu;
    Sprite currentIdle;
    public KeyCode inspectKey;
    public KeyCode storeKey;
    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        spriteRenderer_ = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentIdle = idleForward;
        gameObject.transform.position = GameState.GetInstance().Player;
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
            currentIdle = idleRight;
            animator.Play("MapPlayerRightAnimation");
        }
        else if (movement.x < 0)
        {
            currentIdle = idleLeft;
            animator.Play("MapPlayerLeftAnimation");
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
    void OnTriggerStay2D(Collider2D collider) 
    {
        Inspectable inspect = collider.GetComponent<Inspectable>();
        if(Input.GetKeyDown(inspectKey)) {
        if(inspect != null){
                inspect.Inspect();

            }
        } else if (Input.GetKeyDown(storeKey) && collider.tag == "Store")
        {
            storeMenu.SetActive(true);
        }
    
    }
}
