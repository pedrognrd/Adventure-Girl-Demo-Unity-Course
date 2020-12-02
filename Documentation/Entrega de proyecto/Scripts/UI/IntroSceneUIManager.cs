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
        // Loading Scene1
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Scene1");
    }
    public void LoadStoredGame()
    {
        // Loading Stored game in last scene
        string sceneName = PlayerPrefs.GetString("SceneName");
        GameManager.continueGame = true;
        SceneManager.LoadScene(sceneName);
    }
    public void ConfigGame()
    {
        // TODO
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
