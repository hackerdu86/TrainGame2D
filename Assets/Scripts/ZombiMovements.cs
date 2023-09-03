using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiMovements : MonoBehaviour
{
    private BathroomDoorManager bathroomDoorManager;
    private FirstEncounterWallManager firstEncounterWallManager;
    private bool isOughtToRun = false, isRunning = false, hasRanOnce = false, isBathroomDoorClosed = false;
    private Vector3 secondPosition; 
    private const float SPEED = 6.2f;
    void Start()
    {
        bathroomDoorManager = GameObject.Find("DoorTrigger").GetComponent<BathroomDoorManager>();
        firstEncounterWallManager = GameObject.Find("FirstEncounterWall").GetComponent<FirstEncounterWallManager>();
    }

    void Update()
    {
        isRunning = false;
        isBathroomDoorClosed = bathroomDoorManager.GetIsDoorClosed();
        if (firstEncounterWallManager.GetHasPlayerEntered())
        {
            isOughtToRun = true;
        }
        if (isBathroomDoorClosed)
        {
            isOughtToRun = false;
        }
        if (isOughtToRun)
        {
            isRunning = true;
            transform.Translate(new Vector3(-SPEED * Time.deltaTime, 0, 0));
        }
    }
    public bool GetIsRunning()
    {
        return isRunning;
    }
    public void SetIsOughtToRun(bool _isOughtToRun)
    {
        isOughtToRun = _isOughtToRun;
    }
}
