using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBack : MonoBehaviour
{
   public float forceHorizontal;
    public float forceVertical;

    private Rigidbody2D rigidBody2D;
    private int direction;
    private bool canJump = true;
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // When is damaged, player jumps back
    public void JumpingBack()
    {
        // If player can not jump
        if (!canJump) return;
        
        // If player is in god mode, nothing happens
        if (GameObject.Find("GameManager").GetComponent<GameManager>().godMode) return;

        Vector2 jumpDirection = new Vector2(forceHorizontal * direction, forceVertical);
        GetComponent<PlayerMove>().Beingfired();
        //No depende de nada
        GetComponent<Rigidbody2D>().velocity = jumpDirection;
        canJump = false;
        Invoke("RecoverState", 0.2f);
    }
    private void FixedUpdate()
    {
        // Direction of the jumping back depending the orientation of the player
        if (rigidBody2D.velocity.x > 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    private void RecoverState()
    {
        canJump = true;
    }
}
