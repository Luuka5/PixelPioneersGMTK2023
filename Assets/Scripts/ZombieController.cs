using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, ICollidable
{
    public LayerMask layerMask;
    public float speed;
    public bool isDirectionRight = true;
    public BoxCollider2D fallingCollider;
    public BoxCollider2D frontCollider;
    public Rigidbody2D rb;
    
    public GameObject childWithCollider;
    private bool isGrounded = false;

    private SkeletonAnimation skeletonAnimation;


    // Start is called before the first frame update
    void Start()
    {
        ChildCollider cColl = childWithCollider.AddComponent<ChildCollider>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        rb = GetComponent<Rigidbody2D>();
        cColl.LinkModels(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(isDirectionRight ? speed : -speed, rb.velocity.y);
        if (isGrounded//LayerMask.GetMask("Ground")
         /*|| !Physics2D.IsTouchingLayers(fallingCollider, 
            layerMask//LayerMask.GetMask("Ground")
        )*/)
        {
            ChangeDirection();
            Debug.Log("isGrounded: "+ isGrounded);
        };
    }

    private void ChangeDirection() {
        isDirectionRight = !isDirectionRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeDirection();
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
