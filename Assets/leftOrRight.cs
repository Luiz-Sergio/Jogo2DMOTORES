using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftOrRight : MonoBehaviour
{
    private float b4 = 0f, now,result;
    private SpriteRenderer sprite;
    private enum MovementState { idle, running, jumping, falling };
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        now = transform.position.x;
        UpdateAnimation(now - b4);
        b4 = now;
        
    }

    private void UpdateAnimation(float result)
    {

        //changing animations
        if (result > 0)
        {

            sprite.flipX = true;
        }
        else if (result < 0)
        {

            sprite.flipX = false;
        }
   
    }
}
