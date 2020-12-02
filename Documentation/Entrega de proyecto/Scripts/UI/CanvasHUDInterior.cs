using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasHUDInterior : MonoBehaviour
{
    private static CanvasHUDInterior _instance;

    private void Awake()
    {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);

        //Patrón Singleton
        if (_instance == null)
        {
            print("estoy en el if de CanvasHUDInterior");
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            print("estoy en el else de CanvasHUDInterior");
            Destroy(this.gameObject);
        }
    }
}
