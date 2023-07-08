using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerLightFlight;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public SoundManager SoundManager;

    private CameraShake camFX;

    // Start is called before the first frame update
    void Start()
    {
        camFX = GameCamera.GetComponent<CameraShake>();

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
        Door.currentlyInDarkTheme = false;
        Lever.currentlyInDarkTheme = false;

        StartCoroutine(camFX.Shake(0.5f, 0.5f));
        SoundManager.SwitchToAliveMusic();
    }
    private void SwitchMusicDead()
    {
        Door.currentlyInDarkTheme = true;
        Lever.currentlyInDarkTheme = true;


        StartCoroutine(camFX.Shake(0.5f, 0.5f));
        SoundManager.SwitchToDeadMusic();
    }
}
