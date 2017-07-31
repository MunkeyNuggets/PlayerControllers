using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Snake : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    float snakeSpeed;
    [SerializeField]
    float upperRightThreshold = .8f;
    [SerializeField]
    float upperLeftThreshold = -.8f;
    [SerializeField]
    float lowerRightThreshold = .1f;
    [SerializeField]
    float lowerLeftThreshold = -.1f;
    [SerializeField]
    float snakeSpeedCap = .2f;
    bool rightCheck = true;
    bool leftCheck = true;
    bool lastRightCheck = false;
    bool lastLeftCheck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        SnakeMove();
    }

    void SnakeMove()
    {
        float moveX = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, snakeSpeed);


        if (moveX >= upperRightThreshold && rightCheck == true && lastRightCheck == false)
        {
            snakeSpeed += .1f;
            rightCheck = false;
            lastRightCheck = true;
            lastLeftCheck = false;
        }
        else if (moveX < upperLeftThreshold && leftCheck == true && lastLeftCheck == false)
        {
            snakeSpeed += .1f;
            leftCheck = false;
            lastRightCheck = false;
            lastLeftCheck = true;
        }

        if (moveX <= lowerRightThreshold && rightCheck == false)
        {
            rightCheck = true;
        }
        else if (moveX >= lowerLeftThreshold && leftCheck == false)
        {
            leftCheck = true;
        }

        if (snakeSpeed > 0)
        {
            snakeSpeed -= Time.deltaTime/4;
        }
        else if (snakeSpeed < 0)
        {
            snakeSpeed = 0;
        }

        if (snakeSpeed >= snakeSpeedCap)
        {
            snakeSpeed = snakeSpeedCap;
        }
    }
}