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
    private const int TIME_TO_RELOAD = 2;

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
    public GameObject prefabImageLife;
    private GameObject panelLifes;
    private Text textScore;
    private GameObject textGameOver;
    private GameObject controlsMobile;

    [Header("HUD STATES")]
    // Current general states of the game
    public int score;
    public int lifesNumber;
    public int maxLifesNumber;

    [SerializeField]
    private bool useVJoystick;

    private void Awake()
    {
        // Capture object references
        panelLifes = GameObject.Find("PanelLifes");
        textScore = GameObject.Find("TextScore").GetComponent<Text>();
        textGameOver = GameObject.Find("TextGameOver");
        textGameOver.SetActive(false);
        controlsMobile = GameObject.Find("ControlsMobile");

        player = GameObject.Find("Player");
        score = 0;
        if (continueGame) RecoverState();
        textScore.text = score.ToString();
        lifesNumber = maxLifesNumber;

        GetComponent<UIManager>().PaintLifesUI(lifesNumber, prefabImageLife, panelLifes);
        if (UsingVJoystick())
        {
            controlsMobile.SetActive(true);
        }
        else
        {
            controlsMobile.SetActive(false);
        }
    }

    private void Update()
    {
        print("score " + score);
    }

    public void DeleteLife()
    {
        if (godMode) return;
        lifesNumber--;
        
        // TODO
        //GameStatusManager.Instance.SetNumeroVidas(numeroVidas);//STATUS DEL JUEGO
        GetComponent<UIManager>().PaintLifesUI(lifesNumber, prefabImageLife, panelLifes);
        if (lifesNumber == 0)
        {
            //GameOver
            textGameOver.SetActive(true);
            player.SetActive(false);
            //Invoke(nameof(LoadIntroScene), TIME_TO_RELOAD);
        }
    }

    private void LoadIntroScene()
    {
        SceneManager.LoadScene("CoverScene");
    }

    public void RecoverState()
    {
        continueGame = false;
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            if (PlayerPrefs.GetInt("HasKey") == 1)
            {
                TakingKey();
            }
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        }
    }

    public void TakingKey()
    {
        hasKey = true;
        GetComponent<UIManager>().ActivateUIKey();
    }

    public void TakingDiamond(string diamondName)
    {
        switch (diamondName)
        {
            case "DiamondBlue" :
                hasDiamondBlue = true;
                break;
            case "DiamondGreen":
                hasDiamondGreen = true;
                break;
            case "DiamondRed":
                hasDiamondRed = true;
                break;
            case "DiamondYellow":
                hasDiamondYellow = true;
                break;
        }

        GetComponent<UIManager>().ActivateUIDiamond(diamondName);
    }

    public void Scoring(int points)
    {
        score += points;
        //GameStatusManager.Instance.SetPuntuacion(puntuacion);//STATUS DEL JUEGO
        textScore.text = score.ToString();
    }

    private bool UsingVJoystick()
    {
        bool mobilePlatfomr =
            ((Application.platform == RuntimePlatform.Android) || (Application.platform == RuntimePlatform.IPhonePlayer));
        if (mobilePlatfomr)
        {
            //En un dispositivo movil
            useVJoystick = true;
        }
        else if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            //En el resto
            useVJoystick = false;
        }
        //En el Editor de Unity
        return useVJoystick;
    }
}
