using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Rabbit : MonoBehaviour {

    public float hop;
    public float speed;
    //public Stopwatch timer;

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
        //was thinking that it could be like a presure point and you build up a meter instead
        float moveZ = Input.GetAxis("Vertical");
        bool flickBegin = false;
        if (moveZ >= 0.03f)
        {
            flickBegin = true;
            while (flickBegin == true)
            {
                float time = 1;
                float endTime = 5;
                if (time < endTime)
                {
                    time += Time.deltaTime;
                    Debug.Log(time);
                }
                flickBegin = false;
                time = 1;
            }
        }
        else
            flickBegin = false;
        Debug.Log(flickBegin);


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