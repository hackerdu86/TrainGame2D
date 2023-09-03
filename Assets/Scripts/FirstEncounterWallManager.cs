using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEncounterWallManager : MonoBehaviour
{
    private GameObject playerGameObject;
    private bool hasPlayerEntered = false;
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            hasPlayerEntered = true;
        }
    }
    public bool GetHasPlayerEntered()
    {
        return hasPlayerEntered;
    }
}
