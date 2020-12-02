using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public int score;
    private GameObject textScore;

    // TODO Tal vez hay que destruir el sound manager también.
    public string[] objectsToDestroy = { "CanvasHUD", "GameManager", "Player", "UIManager" };

    public void DestroyObjects()
    {
        foreach (string objectToDestroy in objectsToDestroy)
        {
            GameObject objectTD = GameObject.Find(objectToDestroy);
            Destroy(objectTD);
        }
    }

    private void CaptureDataHUD()
    {
        score = GameObject.Find("Player").GetComponent<PlayerManager>().score;
        textScore = GameObject.Find("Score");
        textScore.GetComponent<Text>().text = score.ToString();
    }

    public void FinalSentenceWrong()
    {
        GameManager.LoadMyScene("Scene1");
    }

    public void FinalSentenceSuccess()
    {
        GameManager.LoadMyScene("FinishScene");
    }

    public void PrintDataHUD() 
    {
        print("PrintDataHUD, score vale " + score);
        GameObject.Find("Player").GetComponent<PlayerManager>().score = score;
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
    }

    public void ReloadScene() 
    {
        CaptureDataHUD();
        DestroyObjects();
        SceneManager.LoadScene("Scene1");
        //PrintDataHUD();
    }

    public void ReloadInteriorScene()
    {
        DestroyObjects();
        SceneManager.LoadScene("InteriorScene");
        CaptureDataHUD();
    }

    public void ReloadMenu()
    {
        DestroyObjects();
        SceneManager.LoadScene("IntroScene");
    }
}
