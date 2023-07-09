using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springboard : MonoBehaviour
{
    public float springforce = 1f;

    public SoundManager soundManager;

    public float springboardPushdownValue = 0.25f;
    private Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.name != "PlayerFlight")
        {
            collision.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D a);
            if (a != null)
            {
                (a.gameObject.GetComponent<SkeletonAnimation>()).AnimationName = "jump";


                a.velocity = new Vector2(a.velocity.x,   springforce);
                soundManager.PlaySpringboardSFX();
            }

            // animation down
            transform.position = new Vector3(transform.position.x, transform.position.y+springboardPushdownValue, transform.position.z);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // animation up
        transform.position = oldPos;

    }
}
