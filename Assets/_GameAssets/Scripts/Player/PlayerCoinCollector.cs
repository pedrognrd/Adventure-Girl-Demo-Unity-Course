using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private PlayerSoundManager psm;
    private void Awake()
    {
        psm = GetComponent<PlayerSoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            // TODO
            psm.PlayAudioCoin();
            Destroy(collision.transform.parent.gameObject);
            int points = collision.gameObject.GetComponentInParent<Coin>().points;
            GameObject.Find("GameManager").GetComponent<GameManager>().Scoring(points);
        }
    }
}
