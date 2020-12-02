using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthArea : MonoBehaviour
{
    private GameObject player;
    private GameObject healthBar;
    private PlayerManager pm;
    
    private int aportacionSalud = 1;
    private float tiempoEspera = 0.5f;
    
    private void Awake()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine("CargarSalud");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Detiene la carga
            StopAllCoroutines();
        }
    }
    IEnumerator CargarSalud() 
    {
        while (!pm.HealthAtMax()) 
        {
            pm.HealthRecovery(aportacionSalud);
            yield return new WaitForSeconds(tiempoEspera); // con demora
            // yield return new sin demora
        }
    }
}
