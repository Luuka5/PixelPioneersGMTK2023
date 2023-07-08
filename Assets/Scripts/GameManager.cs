using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerLightFlight;

public class GameManager : MonoBehaviour
{
    public SoundManager SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerDarkMovement.PlayerKilled += SwitchMusicDead;
        PlayerControllerLightFlight.PlayerAwoke+= SwitchMusicAlive;
    }


    private void OnDestroy()
    {
        PlayerControllerDarkMovement.PlayerKilled -= SwitchMusicDead;
        PlayerControllerLightFlight.PlayerAwoke -= SwitchMusicAlive;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SwitchMusicAlive()
    {
        SoundManager.SwitchToAliveMusic();
    }
    private void SwitchMusicDead()
    {
        SoundManager.SwitchToDeadMusic();
    }
}
