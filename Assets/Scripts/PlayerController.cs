using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float jumpForce = 5f;

    // not working
    //private float jumpForceMultiplier = 1.5f;
    //private float timeHeldJumpButtonDown = 0f;

    public string aliveTag = "Alive";
    public string deathTag = "Death";


    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Collider2D playerCollider;

    public delegate void KillEvent();
    public static event KillEvent PlayerKilled;

    public delegate void AliveEvent();
    public static event AliveEvent PlayerAwoke;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

    }

    //private void Update()
    //{
    //    // to allow dynamic jumping based on long press

    //    bool jumpInput = Input.GetButtonDown("Jump");

    //    // Jumping
    //    if (jumpInput)
    //    {
    //        if (timeHeldJumpButtonDown <= 1f)
    //            timeHeldJumpButtonDown += 0.01f;
    //    }
        

    //}


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");

        // Move horizontally
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Check if the player is on the ground
        isGrounded = Physics2D.IsTouchingLayers(playerCollider, LayerMask.GetMask("Ground"));
        

        // Jumping
        if (isGrounded && jumpInput >0)
        {
            //float nJmp = jumpForce * (jumpForceMultiplier * timeHeldJumpButtonDown);
            //rb.AddForce(new Vector2(0f, nJmp), ForceMode2D.Impulse);

            //timeHeldJumpButtonDown = 0;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(deathTag))
        {
            if (PlayerKilled != null)
            {
                PlayerKilled.Invoke();
            }
        }

        if (collision.gameObject.CompareTag(aliveTag))
        {
            if (PlayerAwoke != null)
            {
                PlayerAwoke.Invoke();
            }
        }
    }
}
