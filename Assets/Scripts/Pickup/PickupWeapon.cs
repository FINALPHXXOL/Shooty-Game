using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : Pickup
{
    public Weapon weaponToEquip;

    public override void OnTriggerEnter(Collider other)
    {
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
