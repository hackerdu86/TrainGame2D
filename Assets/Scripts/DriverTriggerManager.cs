using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverTriggerManager : MonoBehaviour
{
    GameObject playerGameObject;
    private DialogueBoxManager dialogueBoxManager;
    private List<string> driverDialogues_IDFound, driverDialogues_PoorGuy;
    private bool hasEntered = false, hasFoundStaffId = false;
    void Start()
    {   
        playerGameObject = GameObject.Find("Player");
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        driverDialogues_IDFound = new List<string>()
        {
            "He's got a staff ID on him", "I could use it to open on of these doors."
        };
        driverDialogues_PoorGuy = new List<string>()
        {
            "Poor guy...", "I could've helped him if I knew", "I have to get out of here not to end like this!"
        };
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            hasEntered = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerGameObject)
        {
            hasEntered = true;
        }
    }
    void Update()
    {
        if (hasEntered && Input.GetKeyDown(KeyCode.S))
        {
            dialogueBoxManager.SetDialogues((!hasFoundStaffId) ? driverDialogues_IDFound : driverDialogues_PoorGuy);
            dialogueBoxManager.SetIsOughtoStart(true);
            if (!hasFoundStaffId)
            {
                hasFoundStaffId = true;
            }
        }
    }
}
