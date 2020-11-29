using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public bool dying = false;

    public AudioClip audioDying;
    private AudioSource audioSource;
    


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (dying)
        {
            Invoke(nameof(Dying), 0.6f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
            dying = true;
            animator.SetTrigger("Dying");
            Invoke(nameof(Dying), 0.6f);
        }
    }

    public void Dying()
    {
        Destroy(transform.parent.gameObject);
    }

    public void PlayAudioDying()
    {
        audioSource.PlayOneShot(audioDying);
    }
}
