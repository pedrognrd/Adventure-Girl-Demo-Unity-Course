using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    [Range(0, 100)]
    public int rate;
    [Range(0, 1)]
    public float delay;

    private GameManager gameManager;
    private Renderer renderer;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
    }

    public void GodModeOn()
    {
        StartCoroutine("GodModeCoroutine");
    }

    public void GodModeOnByStar(int newRate)
    {
        print(rate);
        rate += newRate;
        print(rate);
        StartCoroutine("GodModeCoroutine");
    }

    IEnumerator GodModeCoroutine()
    {
        gameManager.godMode = true;
        for (int i = 0; i < rate; i++)
        {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(delay);
        }
        renderer.enabled = true;
        gameManager.godMode = false;
    }
}
