using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public bool dying = false;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
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
            // TODO
            //collision.gameObject.GetComponent<PlayerReaction>().JumpBack();
            //collision.gameObject.GetComponent<PlayerManager>().RecibirDanyo();
            animator.SetTrigger("Dying");
            Invoke(nameof(Dying), 0.6f);
        }
    }

    public void Dying()
    {
        Destroy(transform.parent.gameObject);
    }
}
