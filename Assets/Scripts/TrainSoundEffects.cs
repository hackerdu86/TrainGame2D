using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoundEffects : MonoBehaviour
{
    [SerializeField]
    private AudioClip trainAudioClip, rainAudioClip, trainBreakAudioClip, trainBreakMusic;
    private AudioSource audioSource;
    private const float TRAIN_SOUND_VOLUME = 0.05f;
    private ToiletBowlTriggerManager toiletBowlTriggerManager;
    private WallForSecondDialogueManager wallForFirstActionTrigger;
    private bool hasTrainBreakPlayer = false;
    void Start()
    {
        toiletBowlTriggerManager = GameObject.Find("ToiletBowl").GetComponent<ToiletBowlTriggerManager>();
        wallForFirstActionTrigger = GameObject.Find("WallForSecondDialogue").GetComponent<WallForSecondDialogueManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = trainAudioClip;
        audioSource.loop = true;
        audioSource.volume = TRAIN_SOUND_VOLUME;
        audioSource.Play();
    }

    void Update()
    {
        if (toiletBowlTriggerManager.GetHasUsedToiletBowl() && wallForFirstActionTrigger.GetIsPlayerIn() && !hasTrainBreakPlayer)
        {
            audioSource.PlayOneShot(trainBreakAudioClip);
            audioSource.PlayOneShot(trainBreakMusic);
            audioSource.clip = rainAudioClip;
            audioSource.Play();
            hasTrainBreakPlayer = true;
        }
    }
}
