using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControllerLightFlight : MonoBehaviour
{
    public PlayerControllerDarkMovement otherController;
    public SoundManager soundManager;

    public float speed = 15f;
    public float jumpForce = 5f;

    [HideInInspector]
    public Rigidbody2D rb;

    private Animator anim;

    [HideInInspector]
    public Vector2 AdditionalVelocity;

    private Collider2D playerCollider;

    public string aliveTag = "Corpse";
    public delegate void AliveEvent();
    public static event AliveEvent PlayerAwoke;


    private SkeletonAnimation skeletonAnimation;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        skeletonAnimation = GetComponent<SkeletonAnimation>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        if (horizontalInput >= 0.5f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            skeletonAnimation.AnimationName = "run";
        }
        else if (horizontalInput <= -0.5)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            skeletonAnimation.AnimationName = "run";
        }
        else
        {
            skeletonAnimation.AnimationName = "idle";
        }
    }


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed + AdditionalVelocity;
        AdditionalVelocity = Vector2.MoveTowards(AdditionalVelocity, Vector2.zero, 100 * Time.fixedDeltaTime);

        rb.velocity =  movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(aliveTag))
        {
            if (PlayerAwoke != null)
            {
                skeletonAnimation.AnimationName = "inhabit";

                PlayerAwoke.Invoke();
                soundManager.PlayAliveSFX();
            }

            Destroy(collision.gameObject);

            otherController.gameObject.transform.position = gameObject.transform.position;
            otherController.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
