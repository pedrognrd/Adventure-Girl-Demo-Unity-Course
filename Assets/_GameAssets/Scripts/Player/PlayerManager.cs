﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager;
    public string diamondName;
    private PlayerSoundManager psm;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        psm = GetComponent<PlayerSoundManager>();
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            diamondName = collision.gameObject.name;
            psm.PlayAudioDiamond();
            GameObject.Find("GameManager").GetComponent<GameManager>().TakingDiamond(diamondName);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            psm.PlayAudioKey();
            GameObject.Find("GameManager").GetComponent<GameManager>().TakingKey();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Life"))
        {
            psm.PlayAudioLife();
            GameObject.Find("GameManager").GetComponent<GameManager>().lifesNumber++;
            GameObject.Find("GameManager").GetComponent<GameManager>().AddLifes();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Star"))
        {
            psm.PlayAudioStar();
            GetComponent<GodMode>().GodModeOnByStar(20);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            psm.PlayAudioWater();
            DamageReceived();
        }
    }

    public void DamageReceived()
    {
        if (!gameManager.godMode)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().DeleteLife();
            psm.PlayAudioDamage();
            GetComponent<GodMode>().GodModeOn();
        }
    }
}
