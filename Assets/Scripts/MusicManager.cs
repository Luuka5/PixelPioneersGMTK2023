using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLayer {
    public AudioClip music;
    public int blocksBeforeStart;
    public float volume;
}

public class MusicManager : MonoBehaviour
{
    public MusicState aliveMusic;
    public MusicState deadMusic;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Testing());
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    private IEnumerator Testing()
    {
        yield return new WaitForSeconds(5);
        while (true) {
            PlayDeadMusic();
            yield return new WaitForSeconds(10);
            PlayAliveMusic();
            yield return new WaitForSeconds(10);
        }
    } 

    public void PlayDeadMusic()
    {
        deadMusic.Enable();
        aliveMusic.Disable();
    }
    public void PlayAliveMusic()
    {
        deadMusic.Disable();
        aliveMusic.Enable();
    }
}
