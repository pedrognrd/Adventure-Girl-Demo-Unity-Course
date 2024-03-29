﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSunken : MonoBehaviour
{
    bool sunkingHasStarted = false;
    public bool sunking = false;
    public float speed;
    public float waitingTime;

    private void Update()
    {
        // if platform is able to sunking it sunken
        if (sunking)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When platform collides with player, sunken
        if (!sunkingHasStarted && collision.gameObject.CompareTag("Player"))
        {
            sunkingHasStarted = true;
            Invoke("SunkingStarted", waitingTime);
        }
    }

    private void SunkingStarted()
    {
        sunking = true;
    }
}
