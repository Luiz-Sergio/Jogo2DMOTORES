using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private float dirX;
    private BoxCollider2D coll;
    private bool doubleJump = false;

    //variables to give an extra time to jump when off the ground aka coyote time
    public float hangTime = .2f;
    private float hangCounter;

    //to use different hangTimes when firstJump vs extra jumps // first jump small time to jump, extra jump infinite time
    private bool firstJump = true;

    //trying to implement number of jumps
    public int numberOfJumps=1;
    private int numberOfJumpsCounter;

    [SerializeField] private ItemCollector itemCollector;//added by me to implement the double jump only when 2 strawbeerys is collected, so i make a link to the itemCollector script

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private AudioSource jumpSound;
    private enum MovementState { idle, running, jumping, falling };


    // Start is called before the first frame update
    private void Start()
    {
        numberOfJumpsCounter = numberOfJumps;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();   //created to be used in func isGround

    }

    // Update is called once per frame
    private void Update()
    {
        //to prevent player from pressing jump too fast and jumping twice while not decreasing the jump count, because isGround would return true and reset jump count
        if (rb.velocity.y<=0)
        {
            //if player touchs ground reset number of jumps
            if (isGround())
            {
                numberOfJumpsCounter = numberOfJumps;
                firstJump = true;
            }
        }

        //keep track of the coyote time
        if (isGround())
        {
            hangCounter = hangTime;
            
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }

        //moves horizontally
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //if you collect 2 strawBerry you get double jump
        if (itemCollector.strawBerryCount > 1)
        {
            numberOfJumps = 2;
        }
     
        if (Input.GetButtonDown("Jump") && ( (hangCounter > 0f && numberOfJumpsCounter>0 && firstJump) || (!firstJump && numberOfJumpsCounter>0))/*&& numberOfJumpsCounter>0*/  /*!doubleJump*/)
        {
            if(numberOfJumpsCounter == numberOfJumps)
            {
                firstJump = false;
            }

            Debug.Log("NJ: "+numberOfJumpsCounter);

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
            numberOfJumpsCounter--;
        }

        //if player releases the jump button while ascending cut the jump velocy by half
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }     

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MovementState state;

        //changing animations
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;

        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);

    }

    private bool isGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void FixedUpdate()
    {
        
    }
}
