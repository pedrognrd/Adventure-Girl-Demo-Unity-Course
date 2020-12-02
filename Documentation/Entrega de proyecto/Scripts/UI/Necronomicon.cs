using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necronomicon : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Evaluar que el Player tiene la llave
            if (GameManager.hasNecronomicon)
            {
                GameManager.LoadMyScene(sceneName);
            }
        }
    }
}
