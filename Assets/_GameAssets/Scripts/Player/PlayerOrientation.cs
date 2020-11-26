using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    float x;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Player").GetComponent<PlayerAttack>().prefabProjectile.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            GameObject.Find("Player").GetComponent<PlayerAttack>().prefabProjectile.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
