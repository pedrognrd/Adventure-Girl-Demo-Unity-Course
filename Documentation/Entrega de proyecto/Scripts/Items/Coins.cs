using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
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
        // When coin is destroyed, player can see how much pints it will be increase to the score
        if (scoring == false)
        {
            GameObject fn = GameObject.Instantiate(flyingPointsPrefab, transform.position, transform.rotation);
            fn.GetComponent<FlyingPoints>().SetPoints(points);
        }
    }
}
