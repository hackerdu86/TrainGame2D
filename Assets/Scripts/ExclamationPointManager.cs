using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationPointManager : MonoBehaviour
{
    Transform playerTransformComponent;
    BoxCollider2D playerBoxCollider2D;
    private bool exclamationPointSouldBeVisible = false, isInEncounter = false;
    private const float X_OFFSET = 1, Y_POINT = 0.4f, Z_POINT = 0;
    private List<GameObject> gameTriggersObjects = new List<GameObject>();
    void Start()
    {
        playerTransformComponent = GameObject.Find("Player").GetComponent<Transform>();
        playerBoxCollider2D = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        gameTriggersObjects.AddRange(new GameObject[]
        {
            GameObject.Find("ToiletBowl"),
            GameObject.Find("DoorTrigger"),
            GameObject.Find("ExitDoor1"),
            GameObject.Find("ExitDoor2"),
            GameObject.Find("Driver"),
            GameObject.Find("TrainCommandStation")
        });

    }

    // Update is called once per frame
    void Update()
    {
        exclamationPointSouldBeVisible = false;
        foreach (var gameObject in gameTriggersObjects)
        {
            if (playerBoxCollider2D.IsTouching(gameObject.GetComponent<Collider2D>()))
            {
                exclamationPointSouldBeVisible = true;
                break;
            }
        }
        if (exclamationPointSouldBeVisible && !isInEncounter)
        {
            transform.position = new Vector3(playerTransformComponent.position.x + X_OFFSET, Y_POINT, Z_POINT);
        }
        else
        {
            transform.position = new Vector3(0, 0, -30);
        }
    }
    public void SetExclamationPointSouldBeVisible(bool _exclamationPointSouldBeVisible)
    {
        exclamationPointSouldBeVisible = _exclamationPointSouldBeVisible;
    }
}
