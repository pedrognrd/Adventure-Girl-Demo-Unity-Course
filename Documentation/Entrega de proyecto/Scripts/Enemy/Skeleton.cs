using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Animator animator;
    private float currentSpeed;
    [SerializeField]
    private int increaseSpeed;
    private float lastSpeed;
    [SerializeField]
    private float maxDegreeRotation;
    [SerializeField]
    private float minDegreeRotation;
    [SerializeField]
    private float timeBetweenRotation;
    [SerializeField]
    GameObject skeletonSword;

    private void Start()
    {
        currentSpeed = 0;
        lastSpeed = speed;
        InvokeRepeating("Rotate", 0, timeBetweenRotation);
    }

    protected override void Update()
    {
        base.Update();
        AnimationStatus();
    }

    private void AnimationStatus()
    {
        // Posición del player con la Y del enemigo. Para evitar que el enemigo se incline al estar muy cerca del player
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (DistanceToPlayer() <= attackDistance)
        {
            // Reducimos su velocidad
            speed = 0;
            // Se acerca hasta detenerse y comienza a atacar
            animator.SetBool("Attack", true);
        }

        if (DistanceToPlayer() > attackDistance)
        {
            // Recuperamos la velocidad inicial
            speed = lastSpeed;
            // Deja de atacar y comienza a andar
            animator.SetBool("Attack", false);
        }

    }

    public override void Attack()
    {
        if (skeletonSword.GetComponent<SkeletonSword>().canAttack)
        {
            player.GetComponent<PlayerManager>().DamageReceived(damageDone);
        }
    }

    public override void Move()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (DistanceToPlayer() <= attackDistance)
        {
            transform.LookAt(target);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotate()
    {
        transform.Rotate(0, Random.Range(minDegreeRotation, maxDegreeRotation), 0);
    }
}
