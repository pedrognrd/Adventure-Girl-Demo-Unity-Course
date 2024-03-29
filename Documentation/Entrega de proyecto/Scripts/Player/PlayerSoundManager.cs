﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundManager : MonoBehaviour
{
    // setting all the clips of the player
    public AudioClip audioCoin;
    public AudioClip audioDamage;
    public AudioClip audioDiamond;
    public AudioClip audioJump; 
    public AudioClip audioKey;
    public AudioClip audioLife;
    public AudioClip audioLanding;
    public AudioClip audioShoot;
    public AudioClip audioStar;
    public AudioClip audioWater;
    public AudioClip audioDead;
    public AudioClip audioLevelCompleted;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Methos to play all the clips of the player when in case
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

    public void PlayAudioLife()
    {
        audioSource.PlayOneShot(audioLife);
    }
    
    public void PlayAudioDamage()
    {
        audioSource.PlayOneShot(audioDamage);
    }
    public void PlayAudioShoot()
    {
        audioSource.PlayOneShot(audioShoot);
    }

    public void PlayAudioStar()
    {
        audioSource.PlayOneShot(audioStar);
    }
    

    public void PlayAudioWater()
    {
        audioSource.PlayOneShot(audioWater);
    }
    
}
