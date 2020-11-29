using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip audioCoin;
    public AudioClip audioDamage;
    public AudioClip audioDiamond;
    public AudioClip audioJump; 
    public AudioClip audioKey;
    public AudioClip audioLanding;
    public AudioClip audioShoot;
    
    //public AudioClip audioDead;
    public AudioClip audioLevelCompleted;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudioCoin()
    {
        audioSource.PlayOneShot(audioCoin);
    }

    public void PlayAudioDiamond()
    {
        audioSource.PlayOneShot(audioDiamond);
    }
    public void PlayAudioKey()
    {
        audioSource.PlayOneShot(audioKey);
    }
    public void PlayAudioJump()
    {
        audioSource.PlayOneShot(audioJump);
    }
    public void PlayAudioLanding()
    {
        audioSource.PlayOneShot(audioLanding);
    }
    public void PlayAudioDamage()
    {
        audioSource.PlayOneShot(audioDamage);
    }
    public void PlayAudioShoot()
    {
        audioSource.PlayOneShot(audioShoot);
    }
}
