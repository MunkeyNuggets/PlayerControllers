using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rabbit : MonoBehaviour {

    //the RigidBody of the character
    Rigidbody rb;

    //The time the player gets to flick
    public float flickTime;
    //Where the timer starts
    public float lowerThreshold;
    //Where the timer ends
    public float upperThreshold;

    public float lastValueZ;
    //The time the flick began
    public float threshHoldTime;
    //The time taken to complete the flick
    public float timeTaken;
    public bool moveMode = false;
    //A delay variable for the jump if you want to use it
    public float jumpDelay = 1.5f;
    bool flickBegin = false;
    public bool grounded = false;
    //The gravity for the object
    float gravity = 100.0f;
    //How high the object can jump
    float jumpHeight = 2.0f;
    public LayerMask groundLayer;
    public Collider playerCollider;

    //This is for the rotation of the character
    public float speed;


    // Use this for initialization
    void Awake()

    { 
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

	void Start ()
    {
        playerCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        RabbitMove();
        Rotate();
    }

    void RabbitMove()
    {
        //Gets where the stick is on the z Axis
        float valueZ = Input.GetAxis("Vertical");

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

    void Rotate()
    {
        //TODO This can be remapped to your liking (My controllers isn't working so I'm not sure if this even works)
        float rotationSpeed = (Input.GetAxis("Horizontal2") * speed);
        //for some reason "up" works instead of "right"
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}

