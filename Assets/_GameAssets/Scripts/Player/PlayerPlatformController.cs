using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    private const string TAG_ADHERENT = "Adherent";
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(TAG_ADHERENT))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
