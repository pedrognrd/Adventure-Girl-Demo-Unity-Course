using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twistZ : MonoBehaviour
{
    public float angularSpeed;

    void Update()
    {
        transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
    }
}
