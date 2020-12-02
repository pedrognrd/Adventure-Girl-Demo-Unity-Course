using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCharger : MonoBehaviour
{
    public AudioClip acTaken;
    private AudioSource audioSource;
    public int numberChargers;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void PlayChargerTaken()
    {
        audioSource.PlayOneShot(acTaken);
    }
}
