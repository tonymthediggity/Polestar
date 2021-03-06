﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]

public class Equipment : Item {

    public EquipmentSlot equipSlot;

    public int damageResistModifier;
    public int damageModifier;
    public int powerDamageModifier;
    public int cost;

    public int Money;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet, Money}
