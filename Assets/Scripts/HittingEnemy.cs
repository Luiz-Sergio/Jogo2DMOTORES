using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 9f);//little jump when hit the enemy head 
        }
    }

}
