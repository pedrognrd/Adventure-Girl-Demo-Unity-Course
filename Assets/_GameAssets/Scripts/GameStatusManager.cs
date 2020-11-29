using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
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
