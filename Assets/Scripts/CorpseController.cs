using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseController : MonoBehaviour
{
    public float inactiveSeconds = 0f;
    private string initialTag;
    private int initialLayer;
    private Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        if (inactiveSeconds > 0) {
            initialTag = tag;
            initialLayer = gameObject.layer;
            tag = "Untagged";
            gameObject.layer = LayerMask.NameToLayer("InactiveCorpse");
            StartCoroutine(WaitAndAssignTag());
        }   
    }

    
    private IEnumerator WaitAndAssignTag()
    {
        yield return new WaitForSeconds(inactiveSeconds);
        
        if (inactiveSeconds > 0) {
            tag = initialTag;
            gameObject.layer = initialLayer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
