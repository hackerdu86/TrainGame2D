using UnityEngine;

public class Transition
{
    private float pace, middlePace, lastPace, elapsedTime;
    private bool transitionSettingsSet = false, hasAppeared = false, makeDisappear = true;
    private CameraMovement cameraMovementComponent;
    private SpriteRenderer spriteRendererComponent;
    private Transform transitionTransformComponent;
    public Transition(SpriteRenderer _spriteRendererComponent, float _pace)
    {
        spriteRendererComponent = _spriteRendererComponent;
        pace = _pace;
        cameraMovementComponent = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        transitionTransformComponent = spriteRendererComponent.gameObject.GetComponent<Transform>();
        elapsedTime = Time.time;
    }
    public Transition(SpriteRenderer _spriteRendererComponent, float _pace, bool _makeDisappear)
    {
        spriteRendererComponent = _spriteRendererComponent;
        pace = _pace;
        cameraMovementComponent = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        transitionTransformComponent = spriteRendererComponent.gameObject.GetComponent<Transform>();
        elapsedTime = Time.time;
        makeDisappear = _makeDisappear;
    }
    private void MakeTransitionAppear()
    {
        if (spriteRendererComponent.color.a < 1)
        {
            if (Time.time - elapsedTime >= pace)
            {
                spriteRendererComponent.color += new Color(0, 0, 0, 0.01f);
                elapsedTime = Time.time;
            }
        }
        else
        {
            hasAppeared = true;
        }
    }
    private void MakeTransitionDisappear()
    {
        if (spriteRendererComponent.color.a > 0)
        {
            if (Time.time - elapsedTime >= pace)
            {
                spriteRendererComponent.color += new Color(0, 0, 0, -0.01f);
                elapsedTime = Time.time;
            }
        }
    }
    public void StartTransition()
    {
        if (!transitionSettingsSet)
        {
            Vector3 cameraVector3 = cameraMovementComponent.GetVector3();
            transitionTransformComponent.position = new Vector3(cameraVector3.x, cameraVector3.y, 0);
            spriteRendererComponent.color = new Color(0, 0, 0, 0);
            transitionSettingsSet = true;
        }
        if (!hasAppeared)
        {
            MakeTransitionAppear();
        }
        else
        {
            if (makeDisappear)
            {
                MakeTransitionDisappear();
            }
        }
    }
    public bool HasFinished()
    {
        return hasAppeared && spriteRendererComponent.color.a <= 0;
    }
}