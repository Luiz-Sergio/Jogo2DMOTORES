using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("playerMadeContact", true);

        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 30f); 
        Invoke("SetFalse", 0.5f);
    }

    private void SetFalse()
    {
        animator.SetBool("playerMadeContact", false);
    }
}
