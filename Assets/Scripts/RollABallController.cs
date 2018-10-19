using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollABallController : MonoBehaviour {

    [SerializeField]
    float moveForce;
    private float moveVertical, moveHorizontal;
    Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Move();
	}

    void Move()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        myRigidBody.AddForce(movement * moveForce);
    }
}
