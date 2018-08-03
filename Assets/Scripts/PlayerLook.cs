using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    public Transform playerBody;

    public float mouseSensitivity;

    float xAxisClamp = 0.0f;

    private void Awake()
    {
       // Cursor.lockState = CursorLockMode.Locked;

      /*  if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }*/
    }

    private void Update()
    {

       

       // RotateCamera();
    }

    /*void RotateCamera()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotateAmountX = mouseX * mouseSensitivity;
        float rotateAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotateAmountY;

        Vector3 targetRotation = transform.rotation.eulerAngles;
        Vector3 targetRotationBody = playerBody.rotation.eulerAngles;


        targetRotation.x -= rotateAmountY;
        targetRotation.z = 0;
        targetRotation.y += rotateAmountX;
        targetRotationBody.y += rotateAmountX;

        if (xAxisClamp > 45)
        {
            xAxisClamp = 45;
            targetRotation.x = 45;
        }
        else if(xAxisClamp < -15)
        {
            xAxisClamp = -15;
            targetRotation.x = -15;
        }
        

        transform.rotation = Quaternion.Euler(targetRotation);
        playerBody.rotation = Quaternion.Euler(targetRotationBody);

    }*/

    }

