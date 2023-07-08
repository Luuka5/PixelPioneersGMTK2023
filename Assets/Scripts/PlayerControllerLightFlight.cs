using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControllerLightFlight : MonoBehaviour
{
    public PlayerControllerDarkMovement otherController;

    public float speed = 15f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Collider2D playerCollider;



    public string aliveTag = "Corpse";
    public delegate void AliveEvent();
    public static event AliveEvent PlayerAwoke;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();

    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed ;
        rb.velocity =  movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(aliveTag))
        {
            if (PlayerAwoke != null)
            {
                PlayerAwoke.Invoke();

            }

            otherController.gameObject.transform.position = gameObject.transform.position;
            otherController.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
