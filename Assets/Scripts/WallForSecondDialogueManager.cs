using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallForSecondDialogueManager : MonoBehaviour
{
    private DialogueBoxManager dialogueBoxManager;
    private ToiletBowlTriggerManager toiletBowlTriggerManager;
    private GameObject playerGameObjet;
    private bool wasDialogueSet = false, isPlayerIn = false;
    private List<string> trainBreakDialogues;
    void Start()
    {
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        toiletBowlTriggerManager = GameObject.Find("ToiletBowl").GetComponent<ToiletBowlTriggerManager>();
        playerGameObjet = GameObject.Find("Player");
        trainBreakDialogues = new List<string>()
        {
            "...", "Why did the train stop?", "I gotta check that with the train driver I guess.", "What a shitty day!"
        };
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerGameObjet)
        {
            isPlayerIn = true;
            if (toiletBowlTriggerManager.GetHasUsedToiletBowl() && !wasDialogueSet)
            {
                dialogueBoxManager.SetDialogues(trainBreakDialogues);
                dialogueBoxManager.StartDialogueWithTimer(2);
                wasDialogueSet = true;
            }
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerGameObjet)
        {
            isPlayerIn = false;
        }
    }
    public bool GetIsPlayerIn()
    {
        return isPlayerIn;
    }
}
