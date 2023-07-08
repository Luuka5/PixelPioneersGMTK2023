using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerLightFlight;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioPlayer1;


    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer1.GetComponent<AudioSource>();

        //PlayerControllerDarkMovement.PlayerKilled += SwitchMusic;
        //PlayerControllerLightFlight.PlayerAwoke+= SwitchMusic;
    }


    private void OnDestroy()
    {
        PlayerControllerDarkMovement.PlayerKilled -= SwitchMusic;
        PlayerControllerLightFlight.PlayerAwoke -= SwitchMusic;
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
