using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerManager : MonoBehaviour
{
    GameObject playerGameObject;
    private DialogueBoxManager dialogueBoxManager;
    private List<string> exitDoorsDialogues;
    private bool hasEntered = false;
    void Start()
    {   
        playerGameObject = GameObject.Find("Player");
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        exitDoorsDialogues = new List<string>()
        {
            "It is locked...", "I think it might require a staff ID for it to be opened"
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
            dialogueBoxManager.SetDialogues(exitDoorsDialogues);
            dialogueBoxManager.SetIsOughtoStart(true);
        }
    }
}
