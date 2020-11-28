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
       //psm = GetComponent<PlayerSoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            //psm.PlayAudioKey();
            GameObject.Find("GameManager").GetComponent<GameManager>().KeyTaken();
            Destroy(collision.gameObject);
        }
    }

    public void RecibirDanyo()
    {
        if (gameManager.godMode == false)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().DeleteLife();
            //psm.PlayAudioDamage();
            //GetComponent<Flasher>().Flash();//Llamada al Flasher para que parpadee
        }
    }
}
