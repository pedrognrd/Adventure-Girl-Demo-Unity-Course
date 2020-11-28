using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject flyingPointsPrefab;
    public int points;
    private bool scoring = false;

    private void OnApplicationQuit()
    {
        print("OnApplicationQuit");
        scoring = true;
    }
    private void OnDestroy()
    {
        print("OnDestroy");
        if (scoring == false)
        {
            
            GameObject fn = GameObject.Instantiate(flyingPointsPrefab, transform.position, transform.rotation);
            fn.GetComponent<FlyingPoints>().SetPoints(points);
        }
    }
}
