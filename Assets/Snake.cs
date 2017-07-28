using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Snake : MonoBehaviour
{
    public float flickTime;
    public float speed = 10;
    //public Stopwatch timer;
    public float lowerThreshold;
    public float upperThreshold;
    public float lastMoveZ;
    public float threshHoldTime;
    public float timeTaken;
    public bool moveMode = false;
    public float jumpDelay = 1.5f;
    bool flickBegin = false;
    float time = 0;
    float leftRightTurn;
    float rabbitMoveForward;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // PlayerInputBasic();
        RabbitMove();
        //float moveZ = Input.GetAxis("Vertical");
        //Debug.Log(moveZ);

    }
    
    void Movement()
    {

    }

    void RabbitMove()
    {
        //Gets where the stick is on the z Axis
        float moveZ = Input.GetAxis("Vertical");

        if (!moveMode)
        {
            //check if the position of the stick is past the lower set threshold
            if (moveZ >= lowerThreshold)
            {
                //This will check if the lastMoveZ is lower than the lowerThreshold. In a flick, this code will only get to run once.
                if (lastMoveZ < lowerThreshold)
                {
                    flickBegin = true;
                    //the timer the player must beat in order to perform a successful flick starts here.
                    threshHoldTime = Time.time;
                }
            }
            else
            {
                //will keep doing nothing until true
                flickBegin = false;
            }
            if (flickBegin == true)
            {
                //checks when the player has moved the stick into the upperThreshold
                if (moveZ >= upperThreshold)
                {
                    //shows the time the player took to reach the upperThreshold
                    timeTaken = Time.time - threshHoldTime;
                    //Checks to see if the player has performed a successful flick
                    if ((timeTaken) <= flickTime)
                    {
                        //the rabbits moveMode is activated and passes through the 'if'
                        moveMode = true;
                        //Sets a delay so thatthe player can't spam jump
                        rabbitMoveForward += jumpDelay;
                    }
                    flickBegin = false;
                }
            }
        }
        else
        {
            rabbitMoveForward -= Time.deltaTime;
            //Will set the moveMode to false when the rabbitMoveForward timer is up
            if (rabbitMoveForward < 0)
            {
                moveMode = false;
            }
            else if (rabbitMoveForward > jumpDelay)
            {
                rb.AddForce(transform.forward * speed);
            }
        }
        //sets the lastMoveZ
        lastMoveZ = moveZ;
    }
    //This was just used to get a block moving
    void PlayerInputBasic()
    {
        float moveX = Input.GetAxis("Horizontal") * (speed) * (Time.deltaTime);
        float moveZ = Input.GetAxis("Vertical") * (speed) * (Time.deltaTime);
        transform.Translate(0, 0, moveZ);
        //Debug.Log(moveZ);
        transform.Translate(moveX, 0, 0);
    }

}