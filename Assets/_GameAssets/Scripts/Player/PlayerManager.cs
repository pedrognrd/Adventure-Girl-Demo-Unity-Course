using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    //private PlayerSoundManager psm;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // TODO
        //psm = GetComponent<PlayerSoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            // TODO
            //psm.PlayAudioKey();
            GameObject.Find("GameManager").GetComponent<GameManager>().KeyTaken();
            Destroy(collision.gameObject);
        }
    }

    public void DamageReceived()
    {
        if (!gameManager.godMode)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().DeleteLife();
            // TODO
            //psm.PlayAudioDamage();
            GetComponent<GodMode>().GodModeOn();//Llamada al Flasher para que parpadee
        }
    }
}
