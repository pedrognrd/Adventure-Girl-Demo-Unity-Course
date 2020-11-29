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
        scoring = true;
    }
    private void OnDestroy()
    {
        if (scoring == false)
        {
            GameObject fn = GameObject.Instantiate(flyingPointsPrefab, transform.position, transform.rotation);
            fn.GetComponent<FlyingPoints>().SetPoints(points);
        }
    }
}
