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


        if ((xEnemy - xPlayer) < attackDistance)
        {
            GetComponentInParent<TwoPointsMove>().enabled = false;
            animator.SetBool("Throwing", true);
            Throw();
        } else 
        {
            GetComponentInParent<TwoPointsMove>().enabled = true;
            animator.SetBool("Throwing", false);
        }
    }

    public void Throw()
    {
        if (canShoot)
        {
            float direction = spawnPoint.transform.parent.transform.localScale.x;
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
            canShoot = false;
            Invoke(nameof(RestoreThrow), 1);
            //GetComponentInParent<PlayerSoundManager>().PlayAudioFire();
        }
    }

    void RestoreThrow()
    {
        canShoot = true;
    }
}
