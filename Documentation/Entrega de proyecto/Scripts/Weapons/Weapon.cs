using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    //public Text textAmmo;
    //public GameObject textChargers;

    // Definimos los sonidos del arma
    public AudioClip acShoot;
    public AudioClip acReload;
    public AudioClip acStuck;

    // Definimos el resto de variables

    public float cadency; // determina cada cuanto tiempo podemos disparar
    public int maxAmmoByCharger;
    public int maxCharger;
    public int ammo; // munición en el cargador del arma
    public int chargers; // cargadores extras en reserva

    //Accedemos al Audio Source de Arsenal
    private AudioSource audioSource;

    // Variable para determinar si está esperando a que pase el tiempo de cadencia
    private bool isWaiting = false;

    private void Awake()
    {
        //textAmmo = GameObject.Find("TextAmmo").GetComponent<Text>();
        //textChargers = GameObject.Find("TextChargers").GetComponent<Text>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    public void AddChargers(int nc) 
    {
        chargers += nc;
        // Definimos un umbral de valores y recogemos el menor
        chargers = Mathf.Min(chargers, maxCharger);
        GameObject.Find("Reload").GetComponent<Text>().text = "x" + chargers.ToString();
    }

    public void TryShoot()
    {
        if (CanShoot())
        {
            Shoot();
        }
        else {
            PlayStuckSound();
        }
    }

    // Definimos el método de recarga
    public virtual void Reload() 
    {
        if (chargers > 0)
        {
            PlayReloadSound();
            ammo = maxAmmoByCharger;
            chargers--;
            RefreshUI();
        }
    }

    // reproducir el sonido, crear la bala, lanzarla, animaciones, reducir ammo
    // Con virtual podemos definir aquí métodos genéricos y después las clases que hereden, definirán también su método
    public virtual void Shoot()
    {
        isWaiting = true;
        Invoke("ReactivarArma", cadency);
        PlayShootSound();
        ammo--;
        RefreshUI();
    }


    // Actualizamos el HUD
    private void RefreshUI()
    {
        GameObject.Find("Reload").GetComponent<Text>().text = "x" + chargers.ToString();
        //textAmmo.text = ammo.ToString();
        //textChargers.text = "x" + chargers.ToString();
    }
    public bool CanShoot() {
        /*
        * ammo > 0 && cadency (al menos 1 segundo entre disparos)
        * */
        if (isWaiting == false && ammo > 0)
        {
            return true;
        }
        else {
            return false;
        }
    }

    public void PlayShootSound() 
    {
        // Reproduce el sonido del disparo
        audioSource.PlayOneShot(acShoot);
    }

    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(acReload);
    }

    public void PlayStuckSound()
    {
        audioSource.PlayOneShot(acStuck);
    }

    private void ReactivarArma() {
        isWaiting = false;
    }
}
