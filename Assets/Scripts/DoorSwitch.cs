using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {

    public Text text;
    public Interactables interaction;

    public bool canActivate = false;
    public float timer;
    public float timerOpenDoor;
    public bool isDoorActive;
  

    public GameObject door;

	// Use this for initialization
	void Start () {

        
        text.enabled = false;
        isDoorActive = true;

        

		
	}
	
	// Update is called once per frame
	void Update () {

        if (canActivate)
        {
            
            OpenDoor();


            
        }

        if (isDoorActive == false)
        {
            timer = timer + Time.deltaTime;
        }




        if(timer >= timerOpenDoor)
        {
            door.SetActive(true);
            timer = 0;
            isDoorActive = true;
            
        }


        
        

       
		
	}

   
    

    private void MoveDoor()
    {
        
        /*Vector3 doorPos = new Vector3(28, -18, -171);
        door.transform.position = doorPos;*/

        door.SetActive(false);
        isDoorActive = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            canActivate = true;
            text.enabled = true;
            

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        canActivate = false;
        text.enabled = false;
    }

    void OpenDoor()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Door Opening");
            MoveDoor();
        }
    }

    
}
