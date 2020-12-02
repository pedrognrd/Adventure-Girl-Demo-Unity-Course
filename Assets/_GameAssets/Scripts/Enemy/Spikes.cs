using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Spikes attacks Player
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<JumpBack>().JumpingBack();
            collision.gameObject.GetComponent<PlayerManager>().DamageReceived();
        }
    }
}
