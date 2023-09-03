using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Networking;
public class PlayerSoundEffects : MonoBehaviour
{
    private PlayerMovements playerMovements;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClips;
    private AudioManagerMutiple walkAudioManager, runAudioManager;
    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
        audioSource = GetComponent<AudioSource>();
        walkAudioManager = new AudioManagerMutiple(audioSource, 2f, false, audioClips, 0.5f);
        runAudioManager = new AudioManagerMutiple(audioSource, 2f, false, audioClips, 0.42f);

    }

    void Update()
    {
        walkAudioManager.SetConditionForPlaying(playerMovements.IsWalking());
        runAudioManager.SetConditionForPlaying(playerMovements.IsRunning());
        walkAudioManager.StartAudioManagerMutiple();
        runAudioManager.StartAudioManagerMutiple();
    }
}
