using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    // Inventory HUD items
    [Header("INVENTORY")]
    //Inventario
    public bool hasDiamondBlue = false;
    public bool hasDiamondGreen = false;
    public bool hasDiamondRed = false;
    public bool hasDiamondYellow = false;
    public bool hasKey = false;

    [SerializeField]
    private int lifesNumber;
    [SerializeField]
    private int score;

    private static GameStatusManager _instance;
    public static GameStatusManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Next methods are the getters&setters of for most of the HUD items
    public bool GetHasDiamondBlue()
    {
        return hasDiamondBlue;
    }
    public void SetHasDiamondBlue(bool value)
    {
        hasDiamondBlue = value;
    }

    public bool GetHasDiamondGreen()
    {
        return hasDiamondGreen;
    }
    public void SetHasDiamondGreen(bool value)
    {
        hasDiamondGreen = value;
    }
    public bool GetHasDiamondRed()
    {
        return hasDiamondRed;
    }
    public void SetHasDiamondRed(bool value)
    {
        hasDiamondRed = value;
    }
    public void SetHasDiamondYellow(bool value)
    {
        hasDiamondYellow = value;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }
    public void SetHasKey(bool value)
    {
        hasKey = value;
    }
    public bool GetHasDiamondYellow()
    {
        return hasDiamondYellow;
    }

    public int GetLifesNumber()
    {
        return lifesNumber;
    }
    public void SetLifesNumber(int value)
    {
        lifesNumber = value;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score = value;
    }
}
