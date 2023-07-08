using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicState : MonoBehaviour
{
    public List<MusicLayer> layers;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Enable()
    {
        // iterate through all children of this gameobject
        for(int i = 0; i < transform.childCount; i++)
        {
            MusicLayer layer = transform.GetChild(i).GetComponent<MusicLayer>();
            layer.Enable();
        }
    }
    
    public void Disable()
    {
        // iterate through all children of this gameobject
        for(int i = 0; i < transform.childCount; i++)
        {
            MusicLayer layer = transform.GetChild(i).GetComponent<MusicLayer>();
            layer.Disable();
        }
    }
}
