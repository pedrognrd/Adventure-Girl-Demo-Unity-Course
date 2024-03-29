﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    [Header("Projectile Prefab")]
    public GameObject prefabProjectile;
    [Header("Spawner Point")]
    public Transform spawnPoint;
    public float verticalForce = 100;
    [Header("Horizontal Force")]
    [Range(0, 2000)]
    public float horizontalForce;
    private PlayerSoundManager psm;

    /// <summary>
    /// Defines if shooting is able or not
    /// </summary>
    public bool canShoot = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        psm = GetComponent<PlayerSoundManager>();
    }

    private void Update()
    {
        // Controls for firing
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("Shooting", true);
            Fire();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetBool("Shooting", false);
        }
    }

    public void Fire()
    {
        if (canShoot)
        {
            CanShoot();
        }
    }

    // Fire if player is playing with joystick and buttons
    public void FireButton()
    {
        animator.SetBool("Shooting", true);
        if (canShoot)
        {
            CanShoot();
        }
        Invoke(nameof(StopShooting), 0.2f);
    }

    private void CanShoot()
    {
        // Controlling the firing, intantiating the bullets and playing sounds
        float direction = spawnPoint.transform.parent.transform.localScale.x;
        GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
        canShoot = false;
        Invoke(nameof(RestoreFire), 0);
        psm.PlayAudioShoot();
    }

    void RestoreFire()
    {
        canShoot = true;
    }

    // Stop fire animation if player is playing with joystick and buttons
    void StopShooting()
    {
        animator.SetBool("Shooting", false);
    }
}
