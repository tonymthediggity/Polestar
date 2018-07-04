using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    bool isCoolingDown = false;
    public float coolDown = 3;
    public double howLongDashLasts = 0.10;
    






    private void Start()
    {
        
    }


    void Update()
    {
        
        


        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCoolingDown)
        {
            Dash();
            isCoolingDown = true;
            
            
        }

        if(coolDown <= 0)
        {
            isCoolingDown = false;
            coolDown = 3;
            speed = 6;
            howLongDashLasts = .10;
        }

        if (isCoolingDown)
        {
            coolDown -= Time.deltaTime;
            howLongDashLasts -= Time.deltaTime;
        }

        if(howLongDashLasts <= 0)
        {
            speed = 0;
            speed = 6;
        }
       
            

       


    
    }

    void Dash()
    {
        speed = 30;
    }
}
