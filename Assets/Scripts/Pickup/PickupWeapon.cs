using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Pickup
{
    public Weapon weaponToEquip;

    private bool isTriggered = false;
    public override void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return; // Exit if already triggered
        isTriggered = true; // Set flag to true
        // Equip the weapon
        if (weaponToEquip != null)
        {
            Pawn thePawn = other.GetComponent<Pawn>();
            if (thePawn != null)
            {
                thePawn.EquipWeapon(weaponToEquip);
            }
        }

        // Do what happens with all pickups (from the parent class)
        base.OnTriggerEnter(other);
    }
}
