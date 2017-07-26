using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Rabbit : MonoBehaviour {

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

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rabbitMoveForward = 3.0f;
        //timer = new Stopwatch();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // PlayerInputBasic();
        RabbitMove();
        //float moveZ = Input.GetAxis("Vertical");
        //Debug.Log(moveZ);

    }

    void PlayerInputBasic()
    {
        float moveX = Input.GetAxis("Horizontal") * (speed) * (Time.deltaTime);
        float moveZ = Input.GetAxis("Vertical") * (speed) * (Time.deltaTime);
        transform.Translate(0, 0, moveZ);
        //Debug.Log(moveZ);
        transform.Translate(moveX, 0, 0);
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
                //
                if (lastMoveZ < lowerThreshold)
                {
                    flickBegin = true;
                    threshHoldTime = Time.time;
                }
            }
            else
            {
                flickBegin = false;
            }
            if (flickBegin == true)
            {
                if (moveZ >= upperThreshold)
                {
                    timeTaken = Time.time - threshHoldTime;
                    if ((timeTaken) <= flickTime)
                    {
                        moveMode = true;
                        rabbitMoveForward = .5f + jumpDelay;
                    }
                    flickBegin = false;
                }
            }
        }
        else
        {
            rabbitMoveForward -= Time.deltaTime;
            if (rabbitMoveForward < 0)
            {
                moveMode = false;
            }
            else if (rabbitMoveForward > jumpDelay)
            {
                rb.AddForce(transform.forward * speed);
            }
        }
        lastMoveZ = moveZ;
        /*
          * start:
         * lastholding = false
         * update:
         * if not movemode
         *      if holding 
         *          increase rabbitmove by deltatime
         *      end
         *      if not holding and lastholding
         *          movemode = true
         *      end
         *  else
         *      decrease rabbitmove by deltatime
         *      if rabbitmove<0
         *          movemode=false
         *          rabbitmove=0;
         *      else
         *          rigidbody.addforce(transform.forward)
         *      end
         *  end
         *  lastholding=holding

         
         
         
         
         
          * start:
         * lastholding = false
         * currentmove=0
         * startpos (vector3)
         * endpos (VECTOR3)
         * update:
         * if not modemode
         *      if holding 
         *          add value to rabbitmove
         *      end
         *      if not holding and lastholding
         *          movemode = true
         *          currentmove = 0
         *          startpos=transform.pos
         *          endpos=startpos+rabbitmove*tranform.forward
         *      end
         *  else
         *      increase currentmove
         *      if currentmove>rabbitmove
         *          movemode=false
         *          rabbitmove=0;
         *      else
         *          transform.pos = lerp(startpos,endpos,currentmove/rabbitmove)
         *      end
         *  end
         
         
         
         
         */


    }
}