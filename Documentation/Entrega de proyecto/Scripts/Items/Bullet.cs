using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject collisionFind;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When bullet impacts in a enemy
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().dying = true; 
            collision.GetComponent<Animator>().SetTrigger("Dying");
        }
        if (collision.CompareTag("Player") == false)
        {
            // Bullet is destroy only if trigger is not the Player
            Destroy(gameObject);
        }
    }
}
