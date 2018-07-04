using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour {

    GameObject player;
    Rigidbody body;
    public bool dashLeft;


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        body = player.GetComponent<Rigidbody>();
        dashLeft = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A)))
        {
            dashLeft = true;
        }

        if (dashLeft == true)
        {
            body.AddForce(Vector3.left * 500);
            dashLeft = false;
        }

    }
}
