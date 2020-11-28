using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    // Virtual Joystick reference
    public FixedJoystick joystickPlayer;
    // Valour of input's X
    float x;

    private void Awake()
    {
        //Asignación del VIRTUAL JOYSTICK
        if (GameObject.Find("Fixed Joystick") != null)
        {
            joystickPlayer = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        }
    }

    void Update()
    {
        if (joystickPlayer != null && joystickPlayer.isActiveAndEnabled)
        {
            x = joystickPlayer.Horizontal;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
        }

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
