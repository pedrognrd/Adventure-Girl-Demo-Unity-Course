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
            
        }
        if (collision.CompareTag("Enemy") == false)
        {
            //Sólo se destruye si no "hacer trigger" contra el player
            Destroy(gameObject);
        }
    }
}

