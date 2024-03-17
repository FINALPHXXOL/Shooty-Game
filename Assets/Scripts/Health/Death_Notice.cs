using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require a Health Component
[RequireComponent(typeof(Health))]
public class Death_Notice : GameAction
{
    [SerializeField] private float delayBeforeDestruction;

    private void Start()
    {
        // Get the health component
        Health health = GetComponent<Health>();

        // Register with the OnDie event
        health.OnDeath.AddListener(DestroyOnDeath);
    }

    public void DestroyOnDeath()
    {
        print("You've lost yet you still prevail!!!");
    }
}

// In the Pawn