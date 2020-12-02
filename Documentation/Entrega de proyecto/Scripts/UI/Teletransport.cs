using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransport : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    private GameObject gameMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Evaluar que el Player tiene la llave
            if (GameManager.hasKey == true)
            {
                GameManager.LoadMyScene(sceneName);
            }
        }
    }
}
