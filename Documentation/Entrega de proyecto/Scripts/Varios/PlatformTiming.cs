using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTiming : MonoBehaviour
{
    public float timeToActivate;
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Invoke("Activador", timeToActivate);
    }

    private void Activador()
    {
        animator.enabled = true;
    }
}
