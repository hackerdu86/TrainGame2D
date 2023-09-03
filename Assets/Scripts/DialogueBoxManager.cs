using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxManager : MonoBehaviour
{
    private List<string> dialogues;
    private bool hasStarted = false, isOughtoStart = false, isOughtoStartWithTimer = false, isOnEncounter = false, hasFinished = false;
    private GameObject playerGameObject;
    private PlayerMovements playerMovementsComponent;
    private DialogueBox dialogueBox;
    private float currentTime, timeToWait;
    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        playerMovementsComponent = playerGameObject.GetComponent<PlayerMovements>();
    }
    void Update()
    {
        if (isOughtoStartWithTimer)
        {
            if (Time.time - currentTime >= timeToWait)
            {
                isOughtoStart = true;
                isOughtoStartWithTimer = false;
            }
        }
        if (isOughtoStart)
        {
            if (!hasStarted)
            {
                dialogueBox = new DialogueBox(dialogues);
                playerMovementsComponent.SetCanMove(false);
                hasStarted = true;
                hasFinished = false;
            }
            dialogueBox.StartDialogueBox();
            if (dialogueBox.HasFinished())
            {
                dialogueBox.RelocateDialogueBoxElseWhere();
                playerMovementsComponent.SetCanMove(true);
                isOughtoStart = false;
                hasStarted = false;
                hasFinished = true;
            }
        }
    }
    public void SetIsOughtoStart(bool _isOughtoStart)
    {
        isOughtoStart = _isOughtoStart;

    }
    public void StartDialogueWithTimer(float _timeToWait)
    {
        isOughtoStartWithTimer = true;
        timeToWait = _timeToWait;
        InitializeCurrentTime();
    }
    private void InitializeCurrentTime()
    {
        currentTime = Time.time;
    }
    public void SetIsOnEncounter(bool _isOnEncounter)
    {
        isOnEncounter = _isOnEncounter;
    }
    public void SetDialogues(List<string> _dialogues)
    {
        dialogues = _dialogues;
    }
    public bool GetHasDialogueBoxFinished()
    {
        return hasFinished;
    }
    
}
