using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactables {

    public Item item;

   



    public override void Interact()
    {

        


        base.Interact();
        Pickup();
    }

    public void Pickup()
    {
        Debug.Log("Picking up" + item.name);
      bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }

   


}
