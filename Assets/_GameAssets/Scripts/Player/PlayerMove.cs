using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(1, 10)]
    public float forceJump = 1;
    //private bool running = false;
    [Range(1, 1000)]
    public float speed = 10;
    private float x;
    private float y;
    Rigidbody2D rigidBody;
    Animator animator;
    private bool canShoot;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
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

    void Displace()
    {
        rigidBody.velocity = new Vector2(x * Time.deltaTime * speed, rigidBody.velocity.y);

        if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    public void Jump()
    {
        if (Mathf.Abs(rigidBody.velocity.y) < 0.01f)
        {
            rigidBody.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            GameObject.Find("Player").GetComponent<PlayerAttack>().canShoot = false;
        }
    }
}
