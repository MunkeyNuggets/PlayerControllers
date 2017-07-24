using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    public bool hop;
    public float speed;

    float leftRightTurn;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayerInput()
    {
        float moveX = Input.GetAxis("Horizontal") * (speed / 2) * (Time.deltaTime);
        float moveZ = Input.GetAxis("Vertical") * (speed) * (Time.deltaTime);
    }
}