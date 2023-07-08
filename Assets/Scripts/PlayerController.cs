using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public delegate void KillEvent();
    public  KillEvent PlayerKilled;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // if player died here:
        // PlayerKilled.Invoke();

    }
}
