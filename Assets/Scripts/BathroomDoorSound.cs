using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoorSound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;
    BoxCollider2D boxCollider2D;
    bool lastIsTrigger = true, currentIsTrigger = false;
    const float DOOR_VOLUME = 0.15f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        currentIsTrigger = boxCollider2D.isTrigger;
        if (lastIsTrigger != currentIsTrigger)
        {
            lastIsTrigger = currentIsTrigger;
            if (currentIsTrigger)
            {
                audioSource.PlayOneShot(audioClips[1], DOOR_VOLUME);
            }
            else
            {
                audioSource.PlayOneShot(audioClips[0], DOOR_VOLUME);
            }
        }
    }
}
