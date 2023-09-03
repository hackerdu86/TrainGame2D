using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMutiple : AudioManager
{
    private AudioClip[] audioClips;
    private float pace, elapsedTime;
    private int soundIndex;
    public AudioManagerMutiple(AudioSource _audioSource, float _desiredVolume, bool _conditionForPlaying, AudioClip[] _audioClips, float _pace) : base(_audioSource, _desiredVolume, _conditionForPlaying)
    {
        audioClips = _audioClips;
        pace = _pace;
        soundIndex = 0;
        elapsedTime = Time.time;
    }
    public void StartAudioManagerMutiple()
    {
        if (conditionForPlaying && Time.time - elapsedTime >= pace)
        {
            audioSource.clip = audioClips[soundIndex++];
            audioSource.Play();
            if (soundIndex >= audioClips.Length)
            {
                soundIndex = 0;
            }
            elapsedTime = Time.time;
        }
    }
    public void SetConditionForPlaying(bool _conditionForPlaying)
    {
        conditionForPlaying = _conditionForPlaying;
    }
}
