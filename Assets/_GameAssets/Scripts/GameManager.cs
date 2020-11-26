using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // States of the game
    public enum State { GameOver, Menu, Pause, Playing }
    // Info Continue Game
    public static bool continueGame = false;
    // Capture player object reference
    private GameObject player;
    

    [Header("GAME STATE")]
    // Current State of the game
    public State state = State.Menu;

    [Header("INVENTORY")]
    //Inventario
    public bool hasDiamondBlue = false;
    public bool hasDiamondGreen = false;
    public bool hasDiamondRed = false;
    public bool hasDiamondYellow = false;
    public bool hasKey = false;

    [Header("POWERS UP")]
    //--> God Mode, immunity for a while
    public float godModeTime;
    public bool godMode = false;

    [Header("HUD CONFIG")]
    //UI
    public GameObject prefabLifeImage;
    private GameObject panelLifes;
    private Text textScore;
    private GameObject textGameOver;
    private GameObject controlsMobile;

    [Header("HUD STATES")]
    // Current general states of the game
    public int score;
    public int lifesNumber;
    public int maxLifesNumber;

    private void Awake()
    {
        // Capture object references
        panelLifes = GameObject.Find("PanelLIfes");
        textScore = GameObject.Find("TextScore").GetComponent<Text>();
        textGameOver = GameObject.Find("TextGameOver");
        textGameOver.SetActive(false);
        controlsMobile = GameObject.Find("ControlsMobile");

        player = GameObject.Find("Player");
        score = 0;
        if (continueGame) RecoverState();
        textScore.text = score.ToString();
        lifesNumber = maxLifesNumber;

        //GetComponent<UIManager>().CrearVidasUI(numeroVidas, prefabImagenVida, panelVidas);
        /*if (UseVJoystick())
        {
            mobileControls.SetActive(true);
        }
        else
        {
            mobileControls.SetActive(false);
        }*/
    }

    public void RecoverState()
    {
        continueGame = false;
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            if (PlayerPrefs.GetInt("HasKey") == 1)
            {
               // RecogerLlave();
            }
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        }
    }

    public void KeyTaken()
    {
        hasKey = true;
        //GetComponent<UIManager>().ActivarLlaveUI();
    }

}
