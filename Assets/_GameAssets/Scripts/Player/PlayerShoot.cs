using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Animator animator;
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetBool("Shooting", true);
        }

        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            animator.SetBool("Shooting", false);
        }
    }
}
