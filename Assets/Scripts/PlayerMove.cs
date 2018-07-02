using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    CharacterController charControl;
    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody body;


    public void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    public void Update()
    {
        MovePlayer();

       
        
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jumpSpeed = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horizontal * moveSpeed;
        Vector3 moveDirForward = transform.forward * vertical * moveSpeed;
        Vector3 moveDirJump = transform.up * vertical * jumpHeight;
        

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

        if (Input.GetKey(KeyCode.Space))
        {
            moveDirJump.y = jumpHeight;
            Debug.Log("You should be jumping");

            charControl.SimpleMove(moveDirJump);
            
        }

        
    }
}
