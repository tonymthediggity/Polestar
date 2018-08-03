using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    Inventory inventory;

    public Transform itemsParent;

    public GameObject InvUI;
    public GameObject player;
    public bool inventoryIsOpen = false;

  


    InventorySlot[] slots;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        inventory = Inventory.instance;
        inventory.OnItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        InvUI.SetActive(false);
        

        
        
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && !inventoryIsOpen)
        {

            inventoryIsOpen = true;
           // Cursor.lockState = CursorLockMode.None;
            InvUI.SetActive(true);
            player.GetComponent<Gunfire>().enabled = false;
            player.GetComponentInChildren<PlayerLook>().enabled = false;
           

            
            
        }else if(Input.GetKeyDown(KeyCode.Escape) && inventoryIsOpen)
        {
           

                inventoryIsOpen = false;
                //Cursor.lockState = CursorLockMode.Locked;
                InvUI.SetActive(false);
                player.GetComponent<Gunfire>().enabled = true;
                player.GetComponentInChildren<PlayerLook>().enabled = true;
            
        }



    }

    void UpdateUI()
    {
        for(int i = 0; i <  slots.Length; i++)
        {
            if(i < inventory.invItems.Count)
            {
                slots[i].AddItem(inventory.invItems[i]);
            }
            else
            {
                slots[i].RemoveItem(); 
            }
        }
    }

    

    
}
