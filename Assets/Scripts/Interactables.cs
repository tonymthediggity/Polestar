using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour {

    public float radius = 3f;
    Transform player;
    

    public bool canInteract;

    

    private void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= radius)
        {
            canInteract = true;
            
        }
        else
        {
            canInteract = false;
        }

        if(canInteract && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
            Debug.Log("Interacting");
        }
    }

    


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }

    public virtual void Interact()
    {
       
    }


}
