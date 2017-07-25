using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Rabbit : MonoBehaviour {

    public float hop;
    public float speed;
    //public Stopwatch timer;

    float leftRightTurn;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        //timer = new Stopwatch();
	}
	
	// Update is called once per frame
	void Update ()
    {
       // PlayerInputBasic();
        RabbitMove();

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
        float moveZ = Input.GetAxis("Vertical") * (speed) * (Time.deltaTime);
        bool holding = false;
        if (moveZ > 0.03f)
        {
            holding = true;
        }
        else
        holding = false;
        Debug.Log(holding);
    }
}