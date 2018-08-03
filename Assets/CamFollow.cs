using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    Transform targetToFollow;
    public Camera thisCamera;

    

    // Use this for initialization
    void Start () {
        

        targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
        

    }
	
	// Update is called once per frame
	void Update () {

        

        

    }

    private void LateUpdate()
    {

        float scrollWheelZoom = Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(targetToFollow.position.x, targetToFollow.position.y, targetToFollow.position.z);

        if (scrollWheelZoom > 0)
        {

            thisCamera.orthographicSize -= .1f;
            //zoom in
        }

        if (scrollWheelZoom < 0)
        {
            thisCamera.orthographicSize += .1f;
        }
    }


}
