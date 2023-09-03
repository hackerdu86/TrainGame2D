using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallForFirstActionTrigger : MonoBehaviour
{
    private ToiletBowlTriggerManager toiletBowlTriggerManager;
    private DialogueBoxManager dialogueBoxManager;
    private List<string> notTheRightWayDialogues;
    private bool isTriggerSet = false;
    void Start()
    {
        toiletBowlTriggerManager = GameObject.Find("ToiletBowl").GetComponent<ToiletBowlTriggerManager>();
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        notTheRightWayDialogues = new List<string>()
        {
            "I dont think its the right way", "Come on, I gotta find where is that bathroom at!"
        };
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        dialogueBoxManager.SetDialogues(notTheRightWayDialogues);
        dialogueBoxManager.SetIsOughtoStart(true);
    }

    void Update()
    {
        if (toiletBowlTriggerManager.GetHasUsedToiletBowl() && !isTriggerSet)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            isTriggerSet = true;
        }
    }
}
