using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorUI : MonoBehaviour {

    public Inventory inventory;

    public Transform itemsParent;
    public Transform playerPos;

    public GameObject vendorInvUi;
    public GameObject player;
    public GameObject vendor;
    public bool inventoryIsOpen = false;

    public bool isInteracting = false;
    public Text shopText;

    public float radius;
    public bool canInteract;




    InventorySlot[] slots;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        inventory = Inventory.instance;
        inventory.OnItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        vendorInvUi.SetActive(false);
        

        
        
		
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(playerPos.position, transform.position);
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
            vendorInvUi.SetActive(false);
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

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.invItems.Count)
            {
                slots[i].AddItem(inventory.invItems[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }

    void VendorInteract()
    {
        vendorInvUi.SetActive(true);
        isInteracting = true;


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    







}










