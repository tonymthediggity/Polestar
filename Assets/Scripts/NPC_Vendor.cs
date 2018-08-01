using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Vendor : MonoBehaviour {

    public GameObject[] itemsForSale;
    Transform player;
    public bool canInteract;
    public float radius = 3;
    public GameObject vendorInvUI;
    public bool isInteracting = false;
    public Text shopText;
    

    

	// Use this for initialization
	void Start () {

        //vendorInvUI.SetActive(false);
       // shopText.enabled = false;

        
		
	}
	
    
	// Update is called once per frame
	void Update () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius)
        {
            canInteract = true;
            shopText.enabled = true;
            

        }
        else
        {
            canInteract = false;
            shopText.enabled = false;
            
        }

        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
           VendorInteract();
            


            Debug.Log("Interacting");
        }

        if (!canInteract)
        {
            vendorInvUI.SetActive(false);
            isInteracting = false;
        }

        if (isInteracting)
        {
            shopText.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<Gunfire>().enabled = false;
            player.GetComponentInChildren<PlayerLook>().enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<Gunfire>().enabled = true;
            player.GetComponentInChildren<PlayerLook>().enabled = true;

        }

       



    }

    void VendorInteract()
    {
        vendorInvUI.SetActive(true);
        isInteracting = true;
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Buy()
    {

    }
}
