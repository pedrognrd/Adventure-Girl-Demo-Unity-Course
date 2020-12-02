using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AttackNinjaBoy : MonoBehaviour
{
    Animator animator;
    public float attackDistancePositive = 6;
    public float attackDistanceNegative = -6;
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
    private float yEnemy; 
    private float xPlayer;
    private float yPlayer;

    /// <summary>
    /// Defines if shooting is able or not
    /// </summary>
    public bool canShoot = true;
    public AudioClip audioShoot;
    AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        // Ninja Boy only attacks if player is a distance to him lower than 6 and only if player is horizontal line with him
        xEnemy = gameObject.transform.position.x;
        yEnemy = gameObject.transform.position.y; 
        xPlayer = player.transform.position.x;
        yPlayer = player.transform.position.y;

        if ((xPlayer - xEnemy) < 0)
        {
            if ((xPlayer - xEnemy) > attackDistanceNegative)
            {
                if ((yPlayer - yEnemy) > 0 && (yPlayer - yEnemy) < 1)
                {
                    AttackOn();
                }
                if ((yPlayer - yEnemy) < 0 || (yPlayer - yEnemy) > 1)
                {
                    AttackOff();
                }
            }

            if ((xPlayer - xEnemy) < attackDistanceNegative)
            {
                AttackOff();
            }
        }

        if ((xPlayer - xEnemy) > 0)
        {
            if ((xPlayer - xEnemy) < attackDistancePositive)
            {
                if ((yPlayer - yEnemy) > 0 && (yPlayer - yEnemy) < 1)
                {
                    AttackOn();
                }
                if ((yPlayer - yEnemy) < 0 || (yPlayer - yEnemy) > 1)
                {
                    AttackOff();
                }
            }

            if ((xPlayer - xEnemy) > attackDistancePositive)
            {
                AttackOff();
            }
        }
    }

    // Stops attacking
    private void AttackOff()
    {
        GetComponentInParent<TwoPointsMove>().enabled = true;
        animator.SetBool("Throwing", false);
    }

    // Starts attacking
    private void AttackOn()
    {
        GetComponentInParent<TwoPointsMove>().enabled = false;
        DetectPayer();
        Throw();
        animator.SetBool("Throwing", true);
    }

    // Detects if player is left or right from Ninja Boy
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

    // Trows kunais
    private void Throw()
    {
        if (canShoot)
        {
            float direction = spawnPoint.transform.parent.transform.localScale.x;
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
            canShoot = false;
            Invoke(nameof(RestoreThrow), 0.9f);
            audioSource.PlayOneShot(audioShoot);
        }
    }

    void RestoreThrow()
    {
        canShoot = true;
    }
}
