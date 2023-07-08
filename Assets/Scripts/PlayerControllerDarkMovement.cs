using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControllerDarkMovement : MonoBehaviour, ICollidable
{
    public PlayerControllerLightFlight otherController;

    public float speed = 15f;
    public float jumpForce = 5f;
    public float raycastDistance = 0.2f;

    public GameObject childWithCollider;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Collider2D playerCollider;

    public string deathTag = "Death";
    public delegate void KillEvent();
    public static event KillEvent PlayerKilled;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChildCollider cColl = childWithCollider.AddComponent<ChildCollider>();
        cColl.LinkModels(this);
    }


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //float jumpInput = Input.GetAxis("Jump");
        bool jumpInput = Input.GetButton("Jump");

        // Move horizontally
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Check if the player is on the ground

        //isGrounded = Physics2D.IsTouchingLayers(playerCollider, LayerMask.GetMask("Ground"));
        //bool isGrounded = CheckGrounded() && Physics2D.IsTouchingLayers(playerCollider, LayerMask.GetMask("Ground"));
        isGrounded = CheckGrounded();

        // Jumping
        if (isGrounded && jumpInput )
        {
            //rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    bool CheckGrounded()
    {
        // Perform a raycast downwards to check if the player is grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.left * 0.3f, Vector2.down, raycastDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return true;
        }

        hit = Physics2D.Raycast(transform.position + Vector3.right * 0.3f, Vector2.down, raycastDistance, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            return true;
        }

        return false;
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

    public void CollisionDetected(Collision2D collision)
    {
        isGrounded = true;
    }

    public void CollisionExited()
    {
        isGrounded = false;
    }
}
