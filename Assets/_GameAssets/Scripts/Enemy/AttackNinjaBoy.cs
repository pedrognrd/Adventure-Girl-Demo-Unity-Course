using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNinjaBoy : MonoBehaviour
{
    Animator animator;
    [Header("Attack Distance")]
    [Range(0, 20)]
    public float attackDistance;
    private float distanceToPlayer;
    GameObject player;
    [Header("Forces")]
    [Range(0, 2000)]
    public float horizontalForce;
    public float verticalForce = 100;
    [Header("Projectile Prefab")]
    public GameObject prefabProjectile;
    [Header("Spawner Point")]
    public Transform spawnPoint;
    private float xEnemy;
    private float xPlayer;
   
    /// <summary>
    /// Defines if shooting is able or not
    /// </summary>
    public bool canShoot = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        xEnemy = gameObject.transform.position.x;
        xPlayer = player.transform.position.x;
 
        // Ninja Boy only attacks when Player is in line with him, but not if player is lower or higher.
        if ((xEnemy - xPlayer) < attackDistance && (player.transform.position.y - gameObject.transform.position.y) < 1)
        {
            // Detects if player is left or right from Ninja Boy
            DetectPayer();
            GetComponentInParent<TwoPointsMove>().enabled = false;
            animator.SetBool("Throwing", true);
            Throw();
        } else 
        {
            GetComponentInParent<TwoPointsMove>().enabled = true;
            animator.SetBool("Throwing", false);
        }

        if (gameObject.GetComponent<Enemy>().dying) {
            animator.SetBool("Throwing", false);
        }
    }

    private void DetectPayer() 
    {
        if (xEnemy - xPlayer > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xEnemy - xPlayer < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Throw()
    {
        if (canShoot)
        {
            float direction = spawnPoint.transform.parent.transform.localScale.x;
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
            canShoot = false;
            Invoke(nameof(RestoreThrow), 0.9f);

            // TODO
            //GetComponentInParent<PlayerSoundManager>().PlayAudioFire();
        }
    }

    void RestoreThrow()
    {
        canShoot = true;
    }
}
