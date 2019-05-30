/* File:    WanderingAI
 * By:      Jakob McFarland
 * Date:    5/30/2019
 * Brief:
 *      Controller for the wandering behavior of map civilian objects.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 0.5f;

    public float Runtime = 0.2f;
    public float RestTime = 0.1f;

    public int type = 0;

    float timer;
    Vector3 start;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // speed = distance/time
    // v = d/t
    void Start()
    {
       start = transform.position;
       animator = GetComponent<Animator>();
       animator.SetBool("XDir", true);
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > RestTime)
        {
            transform.position += direction.normalized * speed;

            if (timer > RestTime + Runtime)
            {
                if (type == 0)
                {
                    direction.x = Random.Range(1, 4);
                    direction.y = Random.Range(1, 2);
                }
                else if (type == 1)
                {
                    direction.x = Random.Range(1, 2);
                    direction.y = Random.Range(1, 4);
                }

                if (transform.position.x > start.x)
                {
                    direction.x = -direction.x;
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }

                if (transform.position.y > start.y)
                {
                    direction.y = -direction.y;

                    if(type == 1)
                    {
                        animator.Play("Civilian3Down");
                    }
                }
                else
                {
                    if (type == 1)
                    {
                        animator.Play("Civilian3Up");
                    }
                }

                timer = 0.0f;    
            }
        }
    }
}