using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomMusic : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip musicAudioClip;
    AudioManagerSingle musicAudioManager;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicAudioManager = new AudioManagerSingle(audioSource, 0.25f, false, musicAudioClip, 0.05f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        musicAudioManager.StartAudioManagerSingle();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        musicAudioManager.SetConditionForPlaying(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        musicAudioManager.SetConditionForPlaying(false);
    }
}
