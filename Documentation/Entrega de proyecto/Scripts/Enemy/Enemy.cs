using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float attackDistance;
    protected bool autodestruccion = false;
    [SerializeField]
    protected int damageDone;
    [SerializeField]
    private AudioClip explosionSound;
    [SerializeField]
    protected float followingDistance;
    private GameObject gameManager;
    [SerializeField]
    private int health;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private AudioClip painSound;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    private int points;
    [SerializeField]
    private GameObject prefabBlood;
    [SerializeField]
    private GameObject prefabHit;
    [SerializeField]
    private GameObject prefabExplosion;
    [SerializeField]
    protected float speed;

    // Start is called before the first frame update
    protected void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move(); 
        
        float distance = DistanceToPlayer();
        if (distance <= attackDistance)
        {
            Attack();
        }
    }

    protected void Blooding(Vector3 bloodPosition)
    {
        GameObject hit = Instantiate(prefabBlood, bloodPosition, transform.rotation);
    }

    public void DamageReceived(int danno)
    {
        GetComponent<AudioSource>().PlayOneShot(painSound);
        health = health - danno;
        healthSlider.value = healthSlider.maxValue - health;
        if (health <= 0)
        {
            Dying(autodestruccion = true);
        }
    }
    public void DamageReceived(int danno, Vector3 position)
    {
        health = health - danno;
        healthSlider.value = healthSlider.maxValue - health;
        if (health > 0)
        {
            Blooding(position);
        }
    }

    protected float DistanceToPlayer()
    {
        Vector3 vDistance = player.transform.position - transform.position;
        float distance = vDistance.magnitude;
        return distance;
    }

    protected void Dying(bool autodestruccion)
    {
        GameObject explosion = Instantiate(prefabExplosion, transform.position, transform.rotation);
        explosion.GetComponent<AudioSource>().clip = explosionSound;
        explosion.GetComponent<AudioSource>().Play();
        Destroy(gameObject);

        if (autodestruccion)
        {
            gameManager = GameObject.Find("GameManager");
            gameManager.GetComponent<GameManager>().UpdateScore(points);
        }
    }

    // Abstract methods
    public abstract void Attack();
    public abstract void Move();
}
