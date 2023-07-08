using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioPlayer1;
    public PlayerController Player;


    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer1.GetComponent<AudioSource>();
        AudioPlayer1.GetComponent<PlayerController>();


        Player.PlayerKilled += SwitchMusic;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchMusic()
    {
        //TODO
        throw new NotImplementedException();
    }


}
