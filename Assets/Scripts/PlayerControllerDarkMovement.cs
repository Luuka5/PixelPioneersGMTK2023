using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControllerDarkMovement : MonoBehaviour
{
    public PlayerControllerLightFlight otherController;

    public float speed = 15f;
    public float jumpForce = 5f;

    // not working
    //private float jumpForceMultiplier = 1.5f;
    //private float timeHeldJumpButtonDown = 0f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Collider2D playerCollider;

    public string deathTag = "Death";
    public delegate void KillEvent();
    public static event KillEvent PlayerKilled;


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

            otherController.gameObject.transform.position = gameObject.transform.position;
            //offset a bit
            //otherController.gameObject.transform.position *= Vector2.up * 1.5f;

            // switch game controllers
            otherController.gameObject.SetActive(true);
                gameObject.SetActive(false);
        }

    }
}
