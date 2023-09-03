using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionerManager : MonoBehaviour
{
    private bool hasStarted = false, isOughtoStart = false;
    private PlayerMovements playerMovementsComponent;
    private SpriteRenderer spriteRenderer;
    private Transition transition;
    void Start()
    {
        playerMovementsComponent = GameObject.Find("Player").GetComponent<PlayerMovements>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transition = new Transition(spriteRenderer, 0.025f);
    }
    void Update()
    {
        if (isOughtoStart)
        {
            if (!hasStarted)
            {
                transition = new Transition(spriteRenderer, 0.025f);
                playerMovementsComponent.SetCanMove(false);
                hasStarted = true;
            }
            transition.StartTransition();
            if (transition.HasFinished())
            {
                playerMovementsComponent.SetCanMove(true);
                isOughtoStart = false;
                hasStarted = false;
            }
        }
    }
    public void SetIsOughtoStart(bool _isOughtoStart)
    {
        isOughtoStart = _isOughtoStart;
    }
    public bool GetIsTransitionFinished()
    {
        return transition.HasFinished();
    }
    public bool IsTransitionStillRunning()
    {
        return isOughtoStart;
    }
}
