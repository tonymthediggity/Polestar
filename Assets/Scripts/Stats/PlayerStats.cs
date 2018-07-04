using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            damageResist.AddModifier(newItem.damageResistModifier);
            damage.AddModifier(newItem.damageModifier);
            powerDamage.AddModifier(newItem.powerDamageModifier);
        }
        if(oldItem != null)
        {
            damageResist.RemoveModifier(oldItem.damageResistModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            powerDamage.RemoveModifier(oldItem.powerDamageModifier);


        }
    }

}
