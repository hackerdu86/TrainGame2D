using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSounds : MonoBehaviour
{
    private ZombiMovements zombiMovements;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClips;
    private AudioManagerMutiple runAudioManager;
    void Start()
    {
        zombiMovements = GetComponent<ZombiMovements>();
        audioSource = GetComponent<AudioSource>();
        runAudioManager = new AudioManagerMutiple(audioSource, 2f, false, audioClips, 0.42f);

    }

    void Update()
    {
        runAudioManager.SetConditionForPlaying(zombiMovements.GetIsRunning());
        runAudioManager.StartAudioManagerMutiple();
    }
}
