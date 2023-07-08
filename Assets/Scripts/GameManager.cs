using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioPlayer1;


    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer1.GetComponent<AudioSource>();

        PlayerController.PlayerKilled += SwitchMusic;
        PlayerController.PlayerAwoke+= SwitchMusic;
    }


    private void OnDestroy()
    {
        PlayerController.PlayerKilled -= SwitchMusic;
        PlayerController.PlayerAwoke -= SwitchMusic;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchMusic()
    {
        Debug.LogWarning("works");
        //TODO
        throw new NotImplementedException();
    }


}
