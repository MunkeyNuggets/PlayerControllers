using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HedgeHog : MonoBehaviour
{

    Rigidbody rb;

    //this is the variable that is added to when the player moves the 
    [SerializeField]
    float hedgeHogSpeed;

    //This is how far you have to mave the stick to the right
    [SerializeField]
    float upperRightThreshold = .8f;

    //This is how far you have to mave the stick to the Left
    [SerializeField]
    float upperLeftThreshold = -.8f;

    [SerializeField]
    float lowerRightThreshold = .1f;
    [SerializeField]
    float lowerLeftThreshold = -.1f;

    //These are the variables that are used to check that the stick has passed through the Centre bounds
    float upperYThreshold = 0.5f;
    float lowerYThreshold = -0.5f;
    bool midCheck = true;

    //The snake speed can't go faster than this variable
    [SerializeField]
    float hedgeHogSpeedCap = .2f;
    bool rightCheck = true;
    bool leftCheck = true;
    bool lastRightCheck = false;
    bool lastLeftCheck = false;

    //This is for the rotation speed of the character
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SnakeMove();
        Rotate();
    }

    void SnakeMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(0, 0, hedgeHogSpeed);



        if (moveX >= upperRightThreshold && rightCheck == true && lastRightCheck == false && midCheck == true)
        {
            hedgeHogSpeed += .1f;
            rightCheck = false;
            lastRightCheck = true;
            lastLeftCheck = false;
            midCheck = false;
        }
        else if (moveX < upperLeftThreshold && leftCheck == true && lastLeftCheck == false && midCheck == true)
        {
            hedgeHogSpeed += .1f;
            leftCheck = false;
            lastRightCheck = false;
            lastLeftCheck = true;
            midCheck = false;
        }

        if (moveY > upperYThreshold || moveY < lowerYThreshold)
        {
            midCheck = true;
        }

        if (moveX <= lowerRightThreshold && rightCheck == false)
        {
            rightCheck = true;
        }
        else if (moveX >= lowerLeftThreshold && leftCheck == false)
        {
            leftCheck = true;
        }

        if (hedgeHogSpeed > 0)
        {
            hedgeHogSpeed -= Time.deltaTime / 4;
        }
        else if (hedgeHogSpeed < 0)
        {
            hedgeHogSpeed = 0;
        }

        if (hedgeHogSpeed >= hedgeHogSpeedCap)
        {
            hedgeHogSpeed = hedgeHogSpeedCap;
        }
    }

    void Rotate()
    {
        //TODO This can be remapped to your liking (My controllers isn't working so I'm not sure if this even works)
        float rotationSpeed = (Input.GetAxis("Horizontal2") * speed);
        //for some reason "up" works instead of "right"
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}