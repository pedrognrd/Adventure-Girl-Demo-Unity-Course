using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    Light lantern;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            lantern.enabled = !lantern.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            lantern.intensity = lantern.intensity + 1;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            lantern.intensity = lantern.intensity - 1;
        }
    }
}
