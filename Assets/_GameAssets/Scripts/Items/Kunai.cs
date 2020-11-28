using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    private GameObject collisionFind;

    private void Awake()
    {
        transform.Rotate(Vector3.forward * -90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<JumpBack>().JumpingBack();
            GameObject.Find("Player").GetComponent<PlayerManager>().DamageReceived();
        }
        if (collision.CompareTag("Enemy") == false)
        {
            // Is only destroyded if impacts agains Player
            Destroy(gameObject);
        }
    }
}

