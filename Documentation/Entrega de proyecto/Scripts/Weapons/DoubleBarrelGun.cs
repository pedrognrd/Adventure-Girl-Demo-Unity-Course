using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleBarrelGun : Weapon
{
    private int damageDone = 25;
    public GameObject prefabProyectil;
    [SerializeField]
    public GameObject[] shells;
    //public Transform transformSpawner;

    private void Start()
    {
        GameObject.Find("Reload").GetComponent<Text>().text = "x" + chargers.ToString();
    }

    public void ActivateShells()
    {
        print("ActivateShells");
        for (int i = 0; i < shells.Length; i++)
        {
            if (i <= maxAmmoByCharger)
            {
                shells[i].SetActive(true);
            }
        }
    }
    public override void Shoot()
    {
        base.Shoot();
        //Lanzamos el rayo desde el punto en el que está la cámara
        RaycastHit hit;
        // Para ello cogemos el objeto con el tag "MainCamera"
        Vector3 origen = Camera.main.transform.position;
        // De ahí, cogemos la posición y marcamos una dirección
        Vector3 direccion = Camera.main.transform.forward;

        // Lanzamos el raycast
        if (Physics.Raycast(origen, direccion, out hit))
        {
            // Enra si choca contra algo
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                print("hit  " + hit);
                hit.transform.gameObject.GetComponentInParent<Enemy>().DamageReceived(damageDone);
            }
            CurrentShells();
        }
    }

    public void CurrentShells()
    {
        if (chargers >= 0)
        {
            GameObject.Find("Shell" + (ammo + 1)).SetActive(false);
        }
        
    }

    public override void Reload()
    {
        base.Reload();
        if (chargers > 0)
        {
            ActivateShells();
            GameObject.Find("Reload").GetComponent<Text>().text = "x" + chargers.ToString();
        }
    }
}
