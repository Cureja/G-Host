using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playLongMeow()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }

    public void playShortMeow()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }


    public void playRoomMusic()
        //pause the town song when playing the room music ig lol
    {
        audioSource.PlayOneShot(audioClips[3]);
    }

    public void playTownMusic()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }

    public void pauseMusic()
    {
        audioSource.Pause();
    }

    public void playMusic()
    {
        audioSource.Play();
    }
}
