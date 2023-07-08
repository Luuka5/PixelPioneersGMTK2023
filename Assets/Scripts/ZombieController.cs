using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public LayerMask layerMask;
    public float speed;
    public bool isDirectionRight = true;
    public BoxCollider2D fallingCollider;
    public BoxCollider2D frontCollider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(isDirectionRight ? speed : -speed, 0, 0);
        if (Physics2D.IsTouchingLayers(frontCollider, 
            layerMask//LayerMask.GetMask("Ground")
        ) /*|| !Physics2D.IsTouchingLayers(fallingCollider, 
            layerMask//LayerMask.GetMask("Ground")
        )*/)
        {
            Debug.Log("Change direction");
            ChangeDirection();
        };
    }

    private void ChangeDirection() {
        isDirectionRight = !isDirectionRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
