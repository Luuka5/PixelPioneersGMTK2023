using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    float lastSwitchTime;
    const float blocDuration = 12.343f;
    public AudioSource mainLoop;
    public AudioSource mainFirst;
    public AudioSource alive1Loop;
    public AudioSource alive2Loop;
    public AudioSource alive3Loop;
    public AudioSource dead1Loop;
    public AudioSource dead2Loop;
    public AudioSource dead3Loop;
    bool isPlayingAlive;
    
    // Start is called before the first frame update
    void StartMusic(){
        SwitchToAliveMusic();
        double startTime = AudioSettings.dspTime + 1f;
        mainFirst.PlayScheduled(startTime);
        mainLoop.PlayScheduled(startTime);
        alive1Loop.PlayScheduled(startTime);
        alive2Loop.PlayScheduled(startTime);
        alive3Loop.PlayScheduled(startTime);
        dead1Loop.PlayScheduled(startTime);
        dead2Loop.PlayScheduled(startTime);
        dead3Loop.PlayScheduled(startTime);
        
        mainFirst.loop = false;
        StartCoroutine(KeepMainLoop());
    }

    private IEnumerator KeepMainLoop()
    {
        yield return new WaitForSeconds(blocDuration);
        mainLoop.volume = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float timeSinceSwitch = Time.time - lastSwitchTime;
        if(isPlayingAlive){
            if(timeSinceSwitch < 3f){
                alive1Loop.volume = timeSinceSwitch/3f;
            }else{
                alive1Loop.volume = 1;
            }
            if(timeSinceSwitch < 10f){
                alive2Loop.volume = timeSinceSwitch/10f;
            }else{
                alive2Loop.volume = 1;
            }
            if(timeSinceSwitch < 15f){
                alive3Loop.volume = timeSinceSwitch/15f;
            }else{
                alive3Loop.volume = 1;
            }
        }else{
            if(timeSinceSwitch < 3f){
                dead1Loop.volume = timeSinceSwitch/3f;
            }else{
                dead1Loop.volume = 1;
            }
            if(timeSinceSwitch < 10f){
                dead2Loop.volume = timeSinceSwitch/10f;
            }else{
                dead2Loop.volume = 1;
            }
            if(timeSinceSwitch < 15f){
                dead3Loop.volume = timeSinceSwitch/15f;
            }else{
                dead3Loop.volume = 1;
            }
        }
    }

    public void SwitchToDeadMusic(){
        isPlayingAlive = false;
        lastSwitchTime = Time.time;
        alive1Loop.volume = 0f;
        alive2Loop.volume = 0f;
        alive3Loop.volume = 0f;
    }

    public void SwitchToAliveMusic(){
        isPlayingAlive = true;
        lastSwitchTime = Time.time;
        dead1Loop.volume = 0f;
        dead2Loop.volume = 0f;
        dead3Loop.volume = 0f;
    }

    void Awake(){
        StartMusic();
    }
}
