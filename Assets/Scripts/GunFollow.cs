using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour {

    
    float mouseSensitivity;
    float xAxisClamp = 0.0f;
    public Transform gunBody;


	// Use this for initialization
	void Start () {
    mouseSensitivity = (gameObject.GetComponent<PlayerLook>().mouseSensitivity);
		
	}
	
	// Update is called once per frame
	void Update () {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotateAmountX = mouseX;
        float rotateAmountY = mouseY;

        xAxisClamp -= rotateAmountY;

        Vector3 targetRotation = transform.rotation.eulerAngles;
        Vector3 targetRotationBody = gunBody.rotation.eulerAngles;


        targetRotation.x -= rotateAmountY;
        targetRotation.z = 0;
        //targetRotation.y += rotateAmountX;
        targetRotationBody.y += rotateAmountX;

        if (xAxisClamp > 45)
        {
            xAxisClamp = 45;
            targetRotation.x = 45;
        }
        else if (xAxisClamp < -15)
        {
            xAxisClamp = -15;
            targetRotation.x = -15;
        }


        transform.rotation = Quaternion.Euler(targetRotation);
        gunBody.rotation = Quaternion.Euler(targetRotationBody);

    }
}
