using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneUIManager : MonoBehaviour
{
    public Button buttonContinue;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            buttonContinue.interactable = true;
        }
    }
    public void LoadScene1()
    {
        //PlayerPrefs.DeleteAll();//Borra todo.
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Scene1");
    }
    public void LoadStoredGame()
    {
        string sceneName = PlayerPrefs.GetString("SceneName");
        GameManager.continueGame = true;
        SceneManager.LoadScene(sceneName);
    }
    public void ConfigGame()
    {
        Debug.LogError("FALTA POR IMPLEMENTAR EL METODO CONFIGGAME");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
