using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float xOffset;
    void Update()
    {
        transform.position = new Vector3(
            target.transform.position.x + xOffset, 
            transform.position.y, 
            transform.position.z);
    }
}
