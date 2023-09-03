using System.Collections.Generic;
using UnityEngine;

public class FirstDialogueManager : MonoBehaviour
{
    private DialogueBoxManager dialogueBoxManager;
    private List<string> firstDialogues;
    private bool hasFirstDialogueBeenSet = false;
    void Start()
    {
        dialogueBoxManager = GameObject.Find("DialogueBox").GetComponent<DialogueBoxManager>();
        firstDialogues = new List<string>()
        {
            "What a beautiful day to visit your brother that lives on the other freaking side of the planet!",
            "Its been literraly 3h ours and we have not arrived yet?!",
            "All that for his wedding to a girl that pisses me off!",
            "I can not get how Jay fell in love for her!",
            "Anyways, I gotta pee..."
        };
    }

    void Update()
    {
        if (!hasFirstDialogueBeenSet)
        {
            dialogueBoxManager.SetDialogues(firstDialogues);
            dialogueBoxManager.SetIsOughtoStart(true);
            hasFirstDialogueBeenSet = true;
        }
    }
    public bool GetHasFirstDialogueBeenSet()
    {
        return hasFirstDialogueBeenSet;
    }
}
