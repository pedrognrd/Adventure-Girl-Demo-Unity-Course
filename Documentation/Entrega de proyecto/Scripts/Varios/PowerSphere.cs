using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSphere : MonoBehaviour
{
    public int healthHealing;
    public float delayAcumulation;
    private GameObject player;
    private PlayerManager pm;

    public AudioClip acSPhere;
    private AudioSource audioSource;

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
            StartCoroutine("ChargeHealth");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator ChargeHealth()
    {
        //while(true)
        while (!pm.HealthAtMax())
        {
            pm.HealthRecovery(healthHealing);
            audioSource.PlayOneShot(acSPhere);
            yield return new WaitForSeconds(delayAcumulation);
        }
    }


}
