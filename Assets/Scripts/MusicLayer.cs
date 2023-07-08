using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicLayer : MonoBehaviour {
    public AudioClip startClip;
    public AudioClip loopClip;
    private AudioSource loopAudioSource;
    private AudioSource startClipAudioSource;
    public float startFadeDuration = 0.2f;
    public float stopFadeDuration = 0.2f;
    public float changeFadeDuration = 0.2f;
    private float startTimeInSeconds;

    void Awake()
    {
        loopAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        loopAudioSource.loop = true;
        loopAudioSource.mute = true;
        loopAudioSource.volume = 0f;
    	loopAudioSource.clip = loopClip;
    	loopAudioSource.Play();

        startClipAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        startClipAudioSource.loop = true;
        startClipAudioSource.mute = true;
        startClipAudioSource.volume = 0f;
    	startClipAudioSource.clip = startClip;
    	startClipAudioSource.Play();

        startTimeInSeconds = Time.time;
    }
    
    public void Enable()
    {
        StartCoroutine(StartMusic());
    }

    public void Disable()
    {
        StartCoroutine(FadeVolume(loopAudioSource, 0f, stopFadeDuration));
        StartCoroutine(FadeVolume(startClipAudioSource, 0f, stopFadeDuration));
    }

    
    private IEnumerator StartMusic()
    {
        //yield return new WaitForSeconds(secondsUntilStart);
        float timeUntilNextBlock =  loopClip.length - ((Time.time - startTimeInSeconds) % loopClip.length);

        yield return FadeVolume(startClipAudioSource, 1f, startFadeDuration);
        yield return new WaitForSeconds(timeUntilNextBlock - changeFadeDuration - startFadeDuration);
        StartCoroutine(FadeVolume(startClipAudioSource, 0f, changeFadeDuration));
        yield return FadeVolume(loopAudioSource, 1f, changeFadeDuration);
    }
    

    private IEnumerator FadeVolume(AudioSource audioSource, float targetVolume, float duration)
    {

        audioSource.mute = false;
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        
        if (targetVolume == 0f) audioSource.mute = true;
        yield break;
    } 
}
