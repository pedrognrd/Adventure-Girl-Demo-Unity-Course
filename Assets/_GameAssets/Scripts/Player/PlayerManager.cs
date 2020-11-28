using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    public string diamondName;
    //private PlayerSoundManager psm;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // TODO
        //psm = GetComponent<PlayerSoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            // TODO
            //psm.PlayAudioKey();
            //GameObject.Find("GameManager").GetComponent<GameManager>().TakingKey();
            //collision.gameObject.GetComponent<Coin>().Scoring();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Diamond"))
        {

            diamondName = collision.gameObject.name;
            // TODO
            //psm.PlayAudioDiamond();
            GameObject.Find("GameManager").GetComponent<GameManager>().TakingDiamond(diamondName);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            // TODO
            //psm.PlayAudioKey();
            GameObject.Find("GameManager").GetComponent<GameManager>().TakingKey();
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
