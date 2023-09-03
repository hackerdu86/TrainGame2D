using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox
{
    private List<string> dialogues;
    private int scene;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private Transform dialogueBoxTransformComponent;
    private TextMeshPro textMechProComponent;
    private float timeWhenInstanciated;
    private bool hasAppeared = false;
    private Vector3 SCALE_WHEN_APPEARED = new Vector3(1.5f, 1.5f, 1), SCALE_WHEN_DISAPEARD = new Vector3(0, 0, 1);
    private const float ORIGINAL_SCALE = 1.5f,
    SPEED = 0.1f, DELTA_SPEED = 25,
    ORIGINAL_X = 0.40f, ORIGINAL_Y = -3.15f;
    private int dialoguesIndex = 0;

    public DialogueBox(List<string> _dialogues)//, AudioSource audioSource, AudioClip audioClip)
    {
        CameraMovement cameraMovementScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        dialogues = _dialogues;
        scene = cameraMovementScript.GetCurrentTrainCompartement();
        //audioSource = _audioSource;
        //audioClip = _audioClip;
        dialogueBoxTransformComponent = GameObject.Find("DialogueBox").GetComponent<Transform>(); ;
        textMechProComponent = GameObject.Find("TextComponent").GetComponent<TextMeshPro>(); ;
        timeWhenInstanciated = Time.time;
        dialogueBoxTransformComponent.localScale = new Vector3(0, 0, 1);
        dialogueBoxTransformComponent.position = new Vector3((float)((scene - 1) * cameraMovementScript.GetCameraWidth()) - ORIGINAL_X, ORIGINAL_Y, 0);
        textMechProComponent.text = dialogues[dialoguesIndex];
    }
    private void MakeDialogueBoxAppear(float speed)
    {
        if (dialogueBoxTransformComponent.localScale.x < ORIGINAL_SCALE)
        {
            dialogueBoxTransformComponent.localScale += new Vector3((speed * Time.deltaTime) * DELTA_SPEED, (speed * Time.deltaTime) * DELTA_SPEED, 0);
        }
        else
        {
            dialogueBoxTransformComponent.localScale = SCALE_WHEN_APPEARED;
            hasAppeared = true;
        }
    }
    private void MakeDialogueBoxDisapear(float speed)
    {
        if (dialogueBoxTransformComponent.localScale.x > 0)
        {
            dialogueBoxTransformComponent.localScale += new Vector3((-speed * Time.deltaTime) * DELTA_SPEED, (-speed * Time.deltaTime) * DELTA_SPEED, 0);
        }
        else
        {
            dialogueBoxTransformComponent.localScale = SCALE_WHEN_DISAPEARD;
        }
    }
    public void StartDialogueBox()
    {
        if (!hasAppeared)
        {
            MakeDialogueBoxAppear(SPEED);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S) && dialoguesIndex < dialogues.Count)
            {
                dialoguesIndex++;
                if (dialoguesIndex < dialogues.Count)
                {
                    textMechProComponent.text = dialogues[dialoguesIndex];
                }
            }
            if (dialoguesIndex == dialogues.Count)
            {
                MakeDialogueBoxDisapear(SPEED);
            }
        }
    }
    public bool HasFinished()
    {
        return hasAppeared && dialogueBoxTransformComponent.localScale.x <= 0;
    }
    public void RelocateDialogueBoxElseWhere()
    {
        dialogueBoxTransformComponent.position = new Vector3(0, 0, -10);
    }
}
