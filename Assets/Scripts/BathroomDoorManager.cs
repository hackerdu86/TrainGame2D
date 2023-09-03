using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoorManager : MonoBehaviour
{
    private GameObject playerGameObject;
    private BoxCollider2D bathroomDoorBoxCollider2D;
    private bool isDoorClosed = false, hasEntered = false;
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        bathroomDoorBoxCollider2D = GameObject.Find("BathroomDoor").GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (hasEntered && Input.GetKeyDown(KeyCode.S))
        {
            bool isTrigger;
            if (isDoorClosed)
            {
                isTrigger = true;
                isDoorClosed = false;
            }
            else
            {
                isTrigger = false;
                isDoorClosed = true;
            }
            bathroomDoorBoxCollider2D.isTrigger = isTrigger;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            hasEntered = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            hasEntered = false;
        }
    }
    public bool GetIsDoorClosed()
    {
        return isDoorClosed;
    }
}
