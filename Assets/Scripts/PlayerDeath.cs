using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//used to restart the lvl

public class PlayerDeath : MonoBehaviour
{

    private Animator animator;//used to activate the trigger
    private Rigidbody2D rigidBody2d;//used to make the RigidBody static, so when the player dies it cant move

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2d = GetComponent<Rigidbody2D>();
    }


        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathTrap") || (collision.gameObject.CompareTag("Enemy")))//know which object you are colliding with
        {
            deathSoundEffect.Play();
            Die();
        }
    }

    private void Die()
    {
        rigidBody2d.bodyType = RigidbodyType2D.Static;//make the player static/dont move
        animator.SetTrigger("death");//activates the trigger associated with the trasition
    }

    private void RestarLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//restart the lvl
    }

}
