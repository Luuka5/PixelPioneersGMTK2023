using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioPlayer1;
    public PlayerController Player;
    public MusicManager MusicManager;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer1.GetComponent<AudioSource>();


        Player.PlayerKilled += SwitchMusic;
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchMusic()
    {
        MusicManager.PlayAliveMusic();
    }

}
