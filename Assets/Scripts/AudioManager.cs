using UnityEngine;
/*
This class serves as an audio manager for either playing one sound at a specfic time with sound volume courbs 
OR playing mutiple sounds at a specific pace and within a specific condition.
*/
public class AudioManager
{
    protected AudioSource audioSource;
    protected float desiredVolume; 
    protected bool conditionForPlaying;
    public AudioManager(AudioSource _audioSource, float _desiredVolume, bool _conditionForPlaying)
    {
        audioSource = _audioSource;
        desiredVolume = _desiredVolume;
        conditionForPlaying = _conditionForPlaying;
        _audioSource.volume = desiredVolume;
    }
}
