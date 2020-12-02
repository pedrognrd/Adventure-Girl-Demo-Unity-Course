using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float yOffset;
    void Start()
    {
        
    }

    void Update()
    {
        //Time.realtimeSinceStartup;
        yOffset = Mathf.Cos(Time.realtimeSinceStartup * 5);
        transform.Translate(0, yOffset * Time.deltaTime, 0);
    }
}
