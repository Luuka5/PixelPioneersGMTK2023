using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerLightFlight;


public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public SoundManager SoundManager;
    public List<GameObject> switchingWalls;


    public static bool currentlyInDarkTheme = false;
    public bool SetDarkFromStart = false;

    private CameraShake camFX;

    bool dontDoCamShakeOnStartUp = true;

    // Start is called before the first frame update
    void Start()
    {
        camFX = GameCamera.GetComponent<CameraShake>();

        PlayerControllerDarkMovement.PlayerKilled += SwitchMusicDead;
        PlayerControllerLightFlight.PlayerAwoke+= SwitchMusicAlive;

        currentlyInDarkTheme = SetDarkFromStart;

        if (currentlyInDarkTheme)
        {
            SwitchMusicDead();
            dontDoCamShakeOnStartUp = false;
        }
        else
        {
            SwitchMusicAlive();
            dontDoCamShakeOnStartUp = false;
        }


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
        currentlyInDarkTheme = false;
        

        foreach (GameObject wall in switchingWalls) {
            SwitchingWall swall = wall.GetComponent<SwitchingWall>();
            if (swall != null)
            {
                wall.SetActive(swall.visibleInDarkTheme);
            } else {
                wall.SetActive(false);
            }
        }

        if(!dontDoCamShakeOnStartUp)
            StartCoroutine(camFX.Shake(0.5f, 0.5f));

        SoundManager.SwitchToAliveMusic();
    }
    
    private void SwitchMusicDead()
    {
        currentlyInDarkTheme = true;

        Debug.Log("music Switched");

        
        foreach (var wall in switchingWalls) {
            SwitchingWall swall = wall.GetComponent<SwitchingWall>();
            if (swall != null)
            {
                Debug.Log("sWall working");
                wall.SetActive(!swall.visibleInDarkTheme);
            } else {
                wall.SetActive(true);
            }
        }

        if (!dontDoCamShakeOnStartUp)
            StartCoroutine(camFX.Shake(0.5f, 0.5f));

        SoundManager.SwitchToDeadMusic();
    }
}
