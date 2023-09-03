using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingManager : MonoBehaviour
{
    private GameObject playerGameObject;
    private TransitionerManager transitionerManager;
    private bool isPlayerDead = false, hasDeathTransitionStarted = false;
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        transitionerManager = GameObject.Find("Transitioner").GetComponent<TransitionerManager>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            isPlayerDead = true;
        }
    }
    void Update()
    {
        if (isPlayerDead && !hasDeathTransitionStarted)
        {
            Debug.Log("lol");
            transitionerManager.SetIsOughtoStart(true);
            hasDeathTransitionStarted = true;
        }
    }
}
