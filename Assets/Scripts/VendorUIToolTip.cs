using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorUIToolTip : MonoBehaviour {

    

    Equipment itemInSlot; // reference to the item in the item slot
    InventorySlot slot; // reference to the item slot itself
    public Text toolTipText; // reference to the text that will dispay on mouse over


    int damage; // integer that will store the damage modifier of the equipment in the attached item slot
    int armor;
    int cost;






    // Use this for initialization
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {

        slot = GetComponentInParent<InventorySlot>(); // finds and sets the attached item slot


        itemInSlot = slot.item as Equipment; // casts the item in the attached item slot as an equipment so we can pull stats  from it


        if (slot.item)
        {
            damage = itemInSlot.damageModifier; // sets the damage integer to the damage modifier of the item in the attached item slot
            armor = itemInSlot.damageResistModifier;
            cost = itemInSlot.cost;
        }




        if (slot.item)
        {
            ChangeUIText();

        }

        if (!slot.item)
        {
            toolTipText.text = "";
        }










    }

    void ChangeUIText()
    {
        toolTipText.text = itemInSlot.name + "\nDamage:  " + damage.ToString() + "\nArmor:  " + armor.ToString() + "\nCost: ";
    }
}
