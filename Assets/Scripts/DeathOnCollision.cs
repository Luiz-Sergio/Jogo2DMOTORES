using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnCollision : MonoBehaviour
{
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GetComponent<BoxCollider2D> ().enabled = false;
            animator.SetTrigger("pigDeath");
        }
    }

    private void PigDestruction(){
        Destroy(gameObject);
    }
}
