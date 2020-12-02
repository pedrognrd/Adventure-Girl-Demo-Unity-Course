using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{
    // Virtual Joystick reference
    public FixedJoystick joystickPlayer;
    // Valour of input's X
    float x;

    private void Start()
    {
        // Detects if we are using Fixed Joystick
        if (GameObject.Find("Joystick") != null)
        {
            joystickPlayer = GameObject.Find("Joystick").GetComponent<FixedJoystick>();
        }
    }

    void Update()
    {
        // Horizontal controls for keyboard and joystick
        if (joystickPlayer != null && joystickPlayer.isActiveAndEnabled)
        {
            x = joystickPlayer.Horizontal;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
        }

        // Orientation of the model inside player left-right
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
