using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy
{
    public AudioClip acRising;
    public Animator animator;
    private AudioSource audioSource;
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

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Start()
    {
        speed = 0;
        currentSpeed = 0;
        lastSpeed = speed;
        InvokeRepeating("Rotate", 0, timeBetweenRotation);
    }

    protected override void Update()
    {
        base.Update();
        if (GameManager.hasKey) 
        {
            lastSpeed = 10;
            WizardRising();
        }
//        wizard.GetComponent<Wizard>().enabled = true;
  //      wizard.GetComponent<Wizard>().WizardRising(); *
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
            //animator.SetBool("Attack", true);
        }

        if (DistanceToPlayer() > attackDistance)
        {
            speed = lastSpeed;
        }

    }

    public override void Attack()
    {
    }

    public override void Move()
    {
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (DistanceToPlayer() <= followingDistance)
        {
            transform.LookAt(target);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void Rotate()
    {
        transform.Rotate(0, Random.Range(minDegreeRotation, maxDegreeRotation), 0);
    }


    public void WizardRising()
    {
        audioSource.PlayOneShot(acRising);
    }
}
