using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointsMove : MonoBehaviour
{
    public Transform initPos;
    public Transform endPos;
    public GameObject objectToMove;
    public float speed;
    public bool rotate;
    private Vector2 newPosition;
    private float pct=0f;//Porcentaje de desplazamiento
    void Update()
    {
        newPosition = Vector2.Lerp(initPos.position, endPos.position, pct);
        objectToMove.transform.position = newPosition;
        pct += Time.deltaTime * speed;
        if (pct>=1)
        {
            pct = 1;
            speed*= -1;
            if (rotate) objectToMove.transform.localScale = new Vector2(1, 1);
        }
        if (pct <= 0)
        {
            pct = 0;
            speed*= -1;
            if (rotate) objectToMove.transform.localScale = new Vector2(-1, 1);
        }
    }
}
