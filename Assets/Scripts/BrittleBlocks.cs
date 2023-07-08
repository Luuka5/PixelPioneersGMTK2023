using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridleBlocks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Corpse"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "PlayerMovement")
        {         
            Destroy(gameObject);      
        }
    }
}
