using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAltar : MonoBehaviour
{
    public AudioClip acPain;
    private AudioSource audioSource;
    public float delayAcumulation;

    public int healthReduction;
    private GameObject player;
    private PlayerManager pm;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }
    
    private void Start()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayPain();
            StartCoroutine("ReduceHealth");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StopAllCoroutines();
        }
    }

    public void PlayPain()
    {
        audioSource.PlayOneShot(acPain);
    }

    IEnumerator ReduceHealth()
    {
        while (pm.HealthAtMin())
        {
            pm.HealthReduction(healthReduction);
            yield return new WaitForSeconds(delayAcumulation);
        }
    }
}
