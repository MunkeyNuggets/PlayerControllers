using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Snake : MonoBehaviour
{

    Rigidbody rb;
    float snakeSpeed;
    float upperRightThreshold = .8f;
    float upperLeftThreshold = -.8f;
    float lowerRightThreshold = .1f;
    float lowerLeftThreshold = -.1f;
    bool rightCheck = true;
    bool leftCheck = true;

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


        if (moveX >= upperRightThreshold && rightCheck == true)
        {
            snakeSpeed += .1f;
            rightCheck = false;
        }
        else if (moveX < upperLeftThreshold && leftCheck == true)
        {
            snakeSpeed += .1f;
            leftCheck = false;
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
            snakeSpeed -= Time.deltaTime;
        }
        else if (snakeSpeed < 0)
        {
            snakeSpeed = 0;
        }
    }
}