using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridleBlocks : MonoBehaviour
{
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("InactiveCorpse"))
        {
            Destroy(gameObject);
            soundManager.PlayRocksBreakSFX();
        }
        if (collision.gameObject.CompareTag("Corpse"))
        {
            Destroy(gameObject);
            soundManager.PlayRocksBreakSFX();
        }
        if (collision.gameObject.name == "PlayerMovement")
        {         
            Destroy(gameObject);
            soundManager.PlayRocksBreakSFX();
        }
    }
}
