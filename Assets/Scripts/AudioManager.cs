using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
/*
This class serves as an audio manager for either playing one sound at a specfic time with sound volume courbs 
OR playing mutiple sounds at a specific pace and within a specific condition.
*/
public class AudioManager
{
    private AudioSource audioSource;
    private List<AudioClip> audioClips;
    private AudioClip audioClip;
    private float pace, desiredVolume;
    private int soundIndex = 0, timeout;
    private bool conditionForPlaying;
    //Multiple mode constructor
    public AudioManager(AudioSource audioSource, List<AudioClip> audioClips, bool conditionForPlaying, int timeout)
    {
        this.audioSource = audioSource;
        this.audioClips = audioClips;
        this.conditionForPlaying = conditionForPlaying;
        this.timeout = timeout;

    }
    //Single mode constructor
    public AudioManager(AudioSource audioSource, AudioClip audioClip, bool conditionForPlaying, float pace, float desiredVolume)
    {
        this.audioSource = audioSource;
        this.audioClip = audioClip;
        this.conditionForPlaying = conditionForPlaying;
        this.pace = pace;
        this.desiredVolume = desiredVolume;
        audioSource.loop = true;
        audioSource.clip = audioClip;
        audioSource.volume = 0;
    }
    public void ActivateAudioManagerMultipleMode()
    {
        if (conditionForPlaying)
        {
            audioSource.PlayOneShot(audioClips[soundIndex++]);
            if (soundIndex >= audioClips.Count)
            {
                soundIndex = 0;
            }
            Thread.Sleep(timeout);
        }
    }
    public void ActivateAudioManagerSingleMode()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if (conditionForPlaying)
        {
            if (audioSource.volume < desiredVolume)
            {
                audioSource.volume += pace;
            }
        }
        else
        {
            if (audioSource.volume == 0)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.volume -= pace;
            }
        }
        Thread.Sleep(50);
    }
}
