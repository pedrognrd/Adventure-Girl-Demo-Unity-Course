using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    [Header("Prefab del proyectil")]
    public GameObject prefabProjectile;
    [Header("Punto de lanzamiento")]
    public Transform spawnPoint;
    public float verticalForce = 100;
    [Header("Fuerza horizontal")]
    [Range(0, 2000)]
    public float horizontalForce;

    /// <summary>
    /// Determina si se puede disparar o no.
    /// </summary>
    public bool canShoot = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("Shooting", true);
            Fire();
        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("Shooting", false);
        }
    }

    public void Fire()
    {
        if (canShoot)
        {
            float direction = spawnPoint.transform.parent.transform.localScale.x;
            GameObject projectile = Instantiate(prefabProjectile, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce * direction, verticalForce));
            canShoot = false;
            Invoke(nameof(RestoreFire), 0);
            //GetComponentInParent<PlayerSoundManager>().PlayAudioFire();
        }
    }

    void RestoreFire()
    {
        canShoot = true;
    }

}
