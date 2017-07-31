using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rabbit : MonoBehaviour {

    public float flickTime;
    public float speed = 10;
    //public Stopwatch timer;
    public float lowerThreshold;
    public float upperThreshold;
    public float lastValueZ;
    public float threshHoldTime;
    public float timeTaken;
    public bool moveMode = false;
    public float jumpDelay = 1.5f;
    bool flickBegin = false;
    public bool grounded = false;
    float time = 0;
    float leftRightTurn;
    float rabbitMoveForward;
    float gravity = 100.0f;
    float jumpHeight = 2.0f;
    Rigidbody rb;
    public LayerMask groundLayer;
    public Collider playerCollider;

	// Use this for initialization
    void Awake()

    { 
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

	void Start ()
    {
        
        rabbitMoveForward = 3.0f;
        playerCollider = GetComponent<Collider>();

        //timer = new Stopwatch();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
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
        float valueZ = Input.GetAxis("Vertical2");

        if (!moveMode)
        {
            //check if the position of the stick is past the lower set threshold
            if (valueZ >= lowerThreshold)
            {
                //This will check if the lastMoveZ is lower than the lowerThreshold. In a flick, this code will only get to run once.
                if (lastValueZ < lowerThreshold)
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
                if (valueZ >= upperThreshold)
                {
                    //shows the time the player took to reach the upperThreshold
                    timeTaken = Time.time - threshHoldTime;
                    //Checks to see if the player has performed a successful flick
                    if ((timeTaken) <= flickTime)
                    {
                        //the rabbits moveMode is activated and passes through the 'if'
                        moveMode = true;
                        Vector3 val = transform.forward * 2;
                        rb.velocity = new Vector3(val.x, CalculateJumpVerticalSpeed(), val.z);
                    }
                    flickBegin = false;
                }
            }
        }
        if (grounded)
        {
            moveMode = false;
            lastValueZ = valueZ;
        }

        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
    }

    //needs a grouded check
    //needs to jump
    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Debug.Log("We are grounded");
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            Debug.Log("We are not grounded");
            grounded = false;
        }
    }

    

}

