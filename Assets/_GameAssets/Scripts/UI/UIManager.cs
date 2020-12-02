using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Setting all the UI items
    private Image imageKey;
    private Image keyGreen;
    private Image imageDiamondBlue;
    private Image imageDiamondGreen;
    private Image imageDiamondRed;
    private Image imageDiamondYellow;

    private void Awake()
    {
        // link UI items with items in scene
        imageKey = GameObject.Find("ImageKeyOn").GetComponent<Image>();
        imageDiamondBlue = GameObject.Find("ImageDiamondBlueOn").GetComponent<Image>();
        imageDiamondGreen = GameObject.Find("ImageDiamondGreenOn").GetComponent<Image>();
        imageDiamondRed = GameObject.Find("ImageDiamondRedOn").GetComponent<Image>();
        imageDiamondYellow = GameObject.Find("ImageDiamondYellowOn").GetComponent<Image>();
    }

    // Method that activate the key when taken by player
    public void ActivateUIKey() 
    {
        imageKey.enabled = true;
    }

    // Method that activate the diamond taken by player
    // The color of the diamond is a parameter
    public void ActivateUIDiamond(string diamondColor)
    {
        switch (diamondColor)
        {
            case "DiamondBlue":
                imageDiamondBlue.enabled = true;
                break;
            case "DiamondGreen":
                imageDiamondGreen.enabled = true;
                break;
            case "DiamondRed":
                imageDiamondRed.enabled = true;
                break;
            case "DiamondYellow":
                imageDiamondYellow.enabled = true;
                break;
        }
    }

    private void CleanPanelLives(GameObject panelLifes)
    {
        foreach (Transform child in panelLifes.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void PaintLifesUI(int lifesNumber, GameObject prefabImageLife, GameObject panelLifes)
    {
        CleanPanelLives(panelLifes);
        for (int i = 0; i < lifesNumber; i++)
        {
            GameObject newImageLife = Instantiate(prefabImageLife, transform.position, transform.rotation);
            newImageLife.transform.SetParent(panelLifes.transform);
            newImageLife.transform.localScale = Vector3.one;
        }
    }
}
