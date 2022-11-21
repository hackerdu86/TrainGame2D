using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private bool isRunning = false, isWalking = false;
    private const float RUNNING_SPEED = 6f, WALKING_SPEED = 4f;
    private int facingDirection = 1;

    void Start()
    {

    }

    void Update()
    {
        float tempSpeed = 0;
        isRunning = false;
        isWalking = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
            tempSpeed = -WALKING_SPEED;
            facingDirection = -1;
            if (Input.GetKey(KeyCode.A))
            {
                isRunning = true;
                isWalking = false;
                tempSpeed = -RUNNING_SPEED;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            isWalking = true;
            tempSpeed = WALKING_SPEED;
            facingDirection = 1;
            if (Input.GetKey(KeyCode.A))
            {
                isRunning = true;
                isWalking = false;
                tempSpeed = RUNNING_SPEED;
            }
        }
        GetComponent<Animator>().SetBool("IsWalking", isWalking);
        GetComponent<Animator>().SetBool("IsRunning", isRunning);
        transform.Translate(new Vector3(tempSpeed * Time.deltaTime, 0, 0));
        transform.localScale = new Vector3(facingDirection, 1, 1);
    }
    //Getters
    public bool IsRunning() 
    {
        return isRunning;
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}
