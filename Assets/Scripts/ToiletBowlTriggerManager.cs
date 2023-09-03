using System.Collections.Generic;
using UnityEngine;

public class ToiletBowlTriggerManager : MonoBehaviour
{
    private GameObject playerGameObject;
    private TransitionerManager transitionerManager;
    private DialogueBoxManager dialogueBoxManager;
    private BathroomDoorManager bathroomDoorManager;
    private List<string> toiletBowlDialogues, notTimeToUseToiletBowlDialogues, doorHasToBeClosedDialogues;
    private bool hasEntered = false, hasUsedToiletBowl = false, hasFeelsGreatAppeared = false;

    void Start()
    {
        playerGameObject = GameObject.Find("Player");
        transitionerManager = GameObject.Find("Transitioner").GetComponent<TransitionerManager>();
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        bathroomDoorManager = GameObject.Find("DoorTrigger").GetComponent<BathroomDoorManager>();
        toiletBowlDialogues = new List<string>()
        {
            "Ahhhhhh....", "feels great"
        };
        notTimeToUseToiletBowlDialogues = new List<string>()
        {
            "I dont thing its the time to do that...", "Gotta find a way to get out of here!"
        };
        doorHasToBeClosedDialogues = new List<string>()
        {
            "I have to close that door before.", "Its a bathroom, not a freaking museum!"
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
            if (!hasUsedToiletBowl)
            {
                if (bathroomDoorManager.GetIsDoorClosed())
                {
                    transitionerManager.SetIsOughtoStart(true);
                    hasUsedToiletBowl = true;
                }
                else
                {
                    dialogueBoxManager.SetDialogues(doorHasToBeClosedDialogues);
                    dialogueBoxManager.SetIsOughtoStart(true);
                }
            }
            if (hasUsedToiletBowl && transitionerManager.GetIsTransitionFinished())
            {
                dialogueBoxManager.SetDialogues(notTimeToUseToiletBowlDialogues);
                dialogueBoxManager.SetIsOughtoStart(true);
            }
        }
        if (hasUsedToiletBowl && transitionerManager.GetIsTransitionFinished() && !hasFeelsGreatAppeared)
        {
            dialogueBoxManager.SetDialogues(toiletBowlDialogues);
            dialogueBoxManager.SetIsOughtoStart(true);
            hasFeelsGreatAppeared = true;
        }
    }
    public bool GetHasUsedToiletBowl()
    {
        return hasUsedToiletBowl;
    }

}
