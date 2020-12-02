using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject endPanel;
    [SerializeField]
    private GameObject gameOverPanel;
    GameObject eventSystemFirstSelected;
    public static bool hasKey = false;
    public static bool hasNecronomicon = false;
    [SerializeField]
    private GameObject panelMenu;
    private static int score;
    public enum State { Playing, Paused, GameOver }
    private static State state = State.Playing;
    [SerializeField]
    private Text textPause;
    [SerializeField]
    private GameObject textScore;
    [SerializeField]
    private GameObject wizard;

    private static GameManager _instance;

    private void Awake()
    {
        state = State.Playing;
        // Patron singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameObject.Find("PlayerSpawner").SetActive(false);
        //wizard.GetComponent<Wizard>().enabled = false;
        player = GameObject.Find("Player");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        else { 
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (state == State.Playing)
            {
                PauseGame();
            }
            else if (state == State.Paused)
            {
                UnpauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (state == State.Playing)
            {
                EndPanel();
            }
            else if (state == State.Paused)
            {
                UnpauseGame();
            }
        }
    }

    public void DoGameOver()
    {
        /*
         *  - Paramos todo
         *  - Mostramos Game Over
         *  - Menu (Restar | Menu | load)
        */

        // Cambiamos el estado
        state = State.GameOver;
        // Poner time scale en 0 y desactivar scripts del player
        StopGame();
        // Activar el menú
        panelMenu.SetActive(true);
        // Desbloqueamos el cursor del ratón
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndPanel()
    {
        // Cambiamos el estado
        state = State.GameOver;
        // Poner time scale en 0 y desactivar scripts del player
        StopGame();
        // Activar el menú EndPanel
        endPanel.SetActive(true);
        // Desbloqueamos el cursor del ratón
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndPanelHidden()
    {
        endPanel.SetActive(false);
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public static void LoadMyScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public static void LoadScene(string nombreEscena) 
    {
        SceneManager.LoadScene(nombreEscena);
    }

    
    private void PauseGame()
    {
        state = State.Paused;
        StopGame();
        textPause.enabled = true;
    }

    private void StopGame()
    {
        player = GameObject.Find("Player");
        Time.timeScale = 0;
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerManager>().enabled = false;
    }
    private void UnpauseGame()
    {
        state = State.Playing;
        Time.timeScale = 1;
        player.GetComponent<PlayerManager>().enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        textPause.enabled = false;
    }

    public void UpdateScore(int puntos)
    {
        score = score + puntos;
        textScore.GetComponent<Text>().text = score.ToString();
        player.GetComponent<PlayerManager>().score = score;
    }    
}
