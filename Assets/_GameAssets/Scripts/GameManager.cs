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
    [SerializeField]
    private Text textPause;
    // Current State of the game
    public State state = State.Menu;

    [Header("CONFIGURATION")]
    //Configuracion
    public bool soundOn = true;
    public bool musicOn = true;

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
    private GameObject textGamePause;
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

        textGamePause = GameObject.Find("TextGamePause");
        textGamePause.SetActive(false);
        controlsMobile = GameObject.Find("ControlsMobile");

        player = GameObject.Find("Player");
        score = 0;
        if (continueGame) StateRecover();
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

    private void Start()
    {
        //STATUS
        if (GameStatusManager.Instance.GetLifesNumber() > 0)
        {
            GetDiamonsStatus();
            lifesNumber = GameStatusManager.Instance.GetLifesNumber();
            GetComponent<UIManager>().PaintLifesUI(lifesNumber, prefabImageLife, panelLifes);
            score = GameStatusManager.Instance.GetScore();
            textScore.text = score.ToString();
        }
        //FIN DE STATUS
    }


    private void Update()
    {
        // TODO PAUSE GAME
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (state == State.Playing)
            {
                PauseGame();
            }
            else if (state == State.Pause)
            {
                UnpauseGame();
            }
        }
    }

    public void AddLifes()
    {
        GameStatusManager.Instance.SetLifesNumber(lifesNumber);//STATUS DEL JUEGO
        GetComponent<UIManager>().PaintLifesUI(lifesNumber, prefabImageLife, panelLifes);
    }
    
    
    public void DeleteLife()
    {
        if (godMode) return;
        lifesNumber--;
        
        // TODO
        GameStatusManager.Instance.SetLifesNumber(lifesNumber);//STATUS DEL JUEGO
        GetComponent<UIManager>().PaintLifesUI(lifesNumber, prefabImageLife, panelLifes);
        if (lifesNumber == 0)
        {
            //GameOver
            textGameOver.SetActive(true);
            player.SetActive(false);
            Invoke(nameof(LoadIntroScene), TIME_TO_RELOAD);
        }
    }

    
    private void GetDiamonsStatus()
    {
        hasDiamondBlue = GameStatusManager.Instance.GetHasDiamondBlue();
        hasDiamondGreen = GameStatusManager.Instance.GetHasDiamondGreen();
        hasDiamondRed = GameStatusManager.Instance.GetHasDiamondRed();
        hasDiamondYellow = GameStatusManager.Instance.GetHasDiamondYellow();

        if (hasDiamondBlue)
        {
            TakingDiamond("DiamondBlue");
        }
        if (hasDiamondGreen)
        {
            TakingDiamond("DiamondGreen");
        }
        if (hasDiamondRed)
        {
            TakingDiamond("DiamondRed");
        }
        if (hasDiamondYellow)
        {
            TakingDiamond("DiamondYellow");
        }
    }

    private void GetKeySatus()
    {
        hasKey = GameStatusManager.Instance.GetHasKey();
        if (hasKey)
        {
            GameStatusManager.Instance.SetHasKey(true);
            GetComponent<UIManager>().ActivateUIKey();
            Destroy(GameObject.Find("KeyGreen"));
        }
    }

    private void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void PauseGame()
    {
        state = State.Pause;
        StopGame();
        textPause.enabled = true;
    }

    public void Scoring(int points)
    {
        score += points;
        //STATUS DEL JUEGO
        GameStatusManager.Instance.SetScore(score);
        textScore.text = score.ToString();
    }

    public void StateRecover()
    {
        continueGame = false;
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        }
        GetKeySatus();
        GetDiamonsStatus();
    }


    public void StateSave()
    {
        //Guardamos la puntuacion, si tenemos llave o no.
        PlayerPrefs.SetInt("Score", score);
        int key = hasKey ? 1 : 0;
        PlayerPrefs.SetInt("HasKey", key);
        PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("x", player.transform.position.x);
        PlayerPrefs.SetFloat("y", player.transform.position.y);
        PlayerPrefs.Save();
    }

    private void StopGame()
    {
        player = GameObject.Find("Player");
        Time.timeScale = 0;
        player.GetComponent<PlayerManager>().enabled = false;
    }


    public void TakingKey()
    {
        hasKey = true;
        GameStatusManager.Instance.SetHasKey(true);
        GetComponent<UIManager>().ActivateUIKey();
    }

    public void TakingDiamond(string diamondName)
    {
        switch (diamondName)
        {
            case "DiamondBlue" :
                hasDiamondBlue = true;
                GameStatusManager.Instance.SetHasDiamondBlue(true);
                Destroy(GameObject.Find("DiamondBlue"));
                break;
            case "DiamondGreen":
                hasDiamondGreen = true;
                GameStatusManager.Instance.SetHasDiamondGreen(true);
                Destroy(GameObject.Find("DiamondGreen"));
                break;
            case "DiamondRed":
                hasDiamondRed = true;
                GameStatusManager.Instance.SetHasDiamondRed(true);
                Destroy(GameObject.Find("DiamondRed"));
                break;
            case "DiamondYellow":
                hasDiamondYellow = true;
                GameStatusManager.Instance.SetHasDiamondYellow(true);
                Destroy(GameObject.Find("DiamondYellow"));
                break;
        }

        GetComponent<UIManager>().ActivateUIDiamond(diamondName);
    }

    private void UnpauseGame()
    {
        state = State.Playing;
        Time.timeScale = 1;
        player.GetComponent<PlayerManager>().enabled = true;
        textPause.enabled = false;
    }

    private bool UsingVJoystick()
    {
        bool mobilePlatform =
            ((Application.platform == RuntimePlatform.Android) || (Application.platform == RuntimePlatform.IPhonePlayer));
        if (mobilePlatform)
        {
            // When using mobile device
            useVJoystick = true;
        }
        else if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            // When using desktop device
            useVJoystick = false;
        }
        return useVJoystick;
    }
}
