using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    protected float defaultSpeed;
    public float maxMoveSpeed;
    public float maxRotationSpeed;
    public float sprintSpeed;
    public Weapon weapon;
    public Transform weaponAttachmentPoint;

    public bool isSprinting;

    public Mover mover;
    public Controller controller;

    // Start is called before the first frame update
    public virtual void Start()
    {
        defaultSpeed = maxMoveSpeed;
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public void EquipWeapon(Weapon weaponToEquip)
    {
        // First, uninstall any weapon we might have
        UnequipWeapon();

        // Instantiate the weapon as a child of the weapon attachment point with the same position and rotation as the weapon attachment point
        //             and save it as the player's weapon
        Debug.Log(weaponToEquip + " " + weaponAttachmentPoint);
        weapon = Instantiate(weaponToEquip, weaponAttachmentPoint) as Weapon;

        // Set the weapon's layer to our layer
        weapon.gameObject.layer = this.gameObject.layer;
    }
    public void UnequipWeapon()
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
        }

        // Set the weapon to null - this should happen automatically, but we can also do it explicitly just to be sure
        weapon = null;
    }


    public abstract void RotateToLookAt(Vector3 targetPoint);

    // Movement
    public abstract void Move(Vector3 direction);
    public abstract void Rotate(float speed);
    public abstract void Sprint();
    public abstract void StopSprint();
}
