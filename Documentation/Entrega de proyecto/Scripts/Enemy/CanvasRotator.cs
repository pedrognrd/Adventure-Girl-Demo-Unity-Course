using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector que calcula la posición desde el canvas hasta el player
        Vector3 vectorCanvasToPlayer = player.transform.position - transform.position;

        // Debug.DrawRay dibuja líneas en una dirección dada
        //Debug.DrawRay(transform.position, vectorCanvasToPlayer, Color.red);

        // Hacemos que DumbEnemy gire hacia el Player una vez calculado el giro.
        transform.rotation = Quaternion.LookRotation(vectorCanvasToPlayer);

    }
}
