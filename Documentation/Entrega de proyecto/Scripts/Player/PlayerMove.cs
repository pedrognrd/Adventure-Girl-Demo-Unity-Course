using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("PLAYER MOVEMENT")]
    [Range(1, 10)]
    public float forceJump = 1;
    [Range(1, 1000)]
    public float speed = 10;

    Animator animator;
    private bool beingFired = false;
    private bool canShoot;
    private FixedJoystick joystickPlayer;
    Rigidbody2D rigidBody;
    private float x;
    private float y;

    private PlayerSoundManager psm;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        psm = GetComponent<PlayerSoundManager>();

        // Detects if we are using Fixed Joystick
        if (GameObject.Find("Joystick") != null)
        {
            joystickPlayer = GameObject.Find("Joystick").GetComponent<FixedJoystick>();
        }
    }

    private void Update()
    {
        // Checking if player is using keyboard or joystick
        if (joystickPlayer != null && joystickPlayer.isActiveAndEnabled)
        {
            x = joystickPlayer.Horizontal;
            y = joystickPlayer.Vertical;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // While displacing or jumping player cannot shoot
        Displace();

        if (Mathf.Abs(rigidBody.velocity.y) == 0f)
        {
            animator.SetBool("Jumping", false);
        }

        if (Mathf.Abs(rigidBody.velocity.x) != 0 || Mathf.Abs(rigidBody.velocity.y) != 0f)
        {
            GameObject.Find("Player").GetComponent<PlayerAttack>().canShoot = false;
        }
        else 
        {
            GameObject.Find("Player").GetComponent<PlayerAttack>().canShoot = true;
        }
    }

    public void Beingfired()
    {
        beingFired = true;
    }

    void Displace()
    {
        if (!beingFired)
        {
            rigidBody.velocity = new Vector2(x * Time.deltaTime * speed, rigidBody.velocity.y);
        }
        
        if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        beingFired = false;
    }

    public void Jump()
    {
        if (Mathf.Abs(rigidBody.velocity.y) < 0.01f)
        {
            rigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            GameObject.Find("Player").GetComponent<PlayerAttack>().canShoot = false;
            psm.PlayAudioJump();
        }
    }
}
