using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public bool dying = false;
    private AudioSource audioSource;
    
    private void Awake()
    {
        // Set animator component
        animator = GetComponentInChildren<Animator>();
        // Set audiosource component
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // When dying, invoke method
        if (dying)
        {
            Invoke(nameof(Dying), 0.6f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If collides with Player
        if (collision.transform.CompareTag("Player"))
        {
            // If enemy is Ninja Boy, he stops attacking before dying
            if (gameObject.layer == 11)
            {
                gameObject.GetComponent<AttackNinjaBoy>().canShoot = false;
            }

            // Player Jumps back
            collision.gameObject.GetComponent<JumpBack>().JumpingBack();
            // Inflicts damage to Player
            collision.gameObject.GetComponent<PlayerManager>().DamageReceived();
            // Enemy dies
            dying = true;
            animator.SetTrigger("Dying");
            Invoke(nameof(Dying), 0.6f);
        }
    }

    // when Enemy dies
    public void Dying()
    {
        Destroy(transform.parent.gameObject);
    }
}
