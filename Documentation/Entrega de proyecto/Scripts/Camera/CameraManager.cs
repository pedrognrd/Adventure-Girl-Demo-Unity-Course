/*
 * By Fernando Paniagua (2020)
 * 
 * Puedes utilizarlo para lo que quieras, pero si ganas mucho dinero me
 * tienes que invitar a comer cordero asado (es voluntario).
 * 
 */


using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    [Range(0,10)]
    public float ortographicSizeMin;
    [Range(0, 10)]
    public float ortographicSizeMax;
    [Range(0,2)]
    public float zoomInSpeed;
    [Range(0, 2)]
    public float zoomOutSpeed;
    [Range(0, 5)]
    public float timeToZoomOut;

    private float ortographicSizeCurrent;
    private CinemachineVirtualCamera cvc;
    private float timeStopped = 0;
    private float offset = 0.1f;
    private void Awake()
    {
        cvc = GetComponent<CinemachineVirtualCamera>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        cvc.Follow = GameObject.Find("Player").transform;
        cvc.LookAt = GameObject.Find("Player").transform;
    }
    void Start()
    {
        ortographicSizeCurrent = ortographicSizeMax;
    }

    void Update()
    {
        if (Mathf.Abs(playerRigidbody.velocity.x) > offset)
        {
            timeStopped = 0;
            IncreaseZoom();
        } else
        {
            timeStopped += Time.deltaTime;
            if (timeStopped > timeToZoomOut)
            {
                DecreaseZoom();
            }
        }
    }

    private void IncreaseZoom()
    {
        ortographicSizeCurrent = ortographicSizeCurrent - zoomInSpeed * Time.deltaTime;
        ortographicSizeCurrent = Mathf.Max(ortographicSizeCurrent, ortographicSizeMin);
        cvc.m_Lens.OrthographicSize = ortographicSizeCurrent;
    }
    private void DecreaseZoom()
    {
        ortographicSizeCurrent = ortographicSizeCurrent + zoomOutSpeed * Time.deltaTime;
        ortographicSizeCurrent = Mathf.Min(ortographicSizeCurrent, ortographicSizeMax);
        cvc.m_Lens.OrthographicSize = ortographicSizeCurrent;
    }
}
