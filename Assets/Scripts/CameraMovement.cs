using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    private Transform playerTransformComponent;
    private double horizontalCameraSize;
    private float initialCameraXAxis;
    private int currentTrainCompartment = 1;
    private List<string> trainCompartmentNames;
    private const int Z_AXIS = -10;

    void Start()
    {
        playerTransformComponent = playerObject.GetComponent<Transform>();
        initialCameraXAxis = transform.position.x;
        horizontalCameraSize = (Camera.main.orthographicSize * 2.0) * Screen.width / Screen.height;
        trainCompartmentNames = new List<string>() 
        {
            "Bathroom", "Way1", "Exit1", "Way2", "Exit2","Way3", "End"
        };
    }

    void Update()
    {
        foreach (var name in trainCompartmentNames)
        {
            if (GameObject.Find(name).GetComponent<BoxCollider2D>().IsTouching(playerObject.GetComponent<BoxCollider2D>()))
            {
                currentTrainCompartment = trainCompartmentNames.IndexOf(name);
            }
        }
        transform.localPosition = new Vector3((float)((currentTrainCompartment*horizontalCameraSize) + initialCameraXAxis), 0, Z_AXIS);
    }
}
