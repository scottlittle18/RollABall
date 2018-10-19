using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollABallController : MonoBehaviour {

    [SerializeField]
    float moveForce;
    private float moveVertical, moveHorizontal;

    public Text countText, winText;

    int pickupCount;
    Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        pickupCount = 0;
        SetCountText();
        winText.text = "";
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            pickupCount++;
            SetCountText();
        }
            
    }

    void SetCountText()
    {
        countText.text = "Count: " + pickupCount.ToString();

        if(pickupCount >= 13)
        {
            winText.text = "YOU WIN!!";
        }
    }
}
