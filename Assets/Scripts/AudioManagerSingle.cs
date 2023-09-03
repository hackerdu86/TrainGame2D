using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSingle : AudioManager
{
    private AudioClip audioClip;
    private float gradiantUp, gradiantDown;
    public AudioManagerSingle(AudioSource _audioSource, float _desiredVolume, bool _conditionForPlaying, AudioClip _audioClip, float _gradiantUp, float _gradiantDown) : base(_audioSource, _desiredVolume, _conditionForPlaying)
    {
        audioClip = _audioClip;
        gradiantUp = _gradiantUp;
        gradiantDown = _gradiantDown;
        audioSource.volume = 0;
    }
    public void StartAudioManagerSingle()
    {
        if (conditionForPlaying)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
            }
            if (audioSource.volume < desiredVolume)
            {
                audioSource.volume += (gradiantUp*Time.deltaTime);
            }
        }
        else
        {
            if (audioSource.volume > 0)
            {
                audioSource.volume += (-gradiantDown*Time.deltaTime);
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
    public void SetConditionForPlaying(bool _conditionForPlaying)
    {
        conditionForPlaying = _conditionForPlaying;
    }
}
