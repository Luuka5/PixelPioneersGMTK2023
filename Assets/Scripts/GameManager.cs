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
        LightController.currentlyInDarkTheme = false;

        foreach (GameObject wall in switchingWalls) {
            SwitchingWall swall = wall.GetComponent<SwitchingWall>();
            if (swall != null)
            {
                wall.SetActive(swall.visibleInDarkTheme);
            } else {
                wall.SetActive(false);
            }
        }

        StartCoroutine(camFX.Shake(0.5f, 0.5f));
        SoundManager.SwitchToAliveMusic();
    }
    private void SwitchMusicDead()
    {
        Debug.Log("music Switched");
        Door.currentlyInDarkTheme = true;
        Lever.currentlyInDarkTheme = true;
        LightController.currentlyInDarkTheme = true;
        
        foreach (var wall in switchingWalls) {
            SwitchingWall swall = wall.GetComponent<SwitchingWall>();
            if (swall != null)
            {
                wall.SetActive(!swall.visibleInDarkTheme);
            } else {
                wall.SetActive(true);
            }
        }

        StartCoroutine(camFX.Shake(0.5f, 0.5f));
        SoundManager.SwitchToDeadMusic();
    }
}
