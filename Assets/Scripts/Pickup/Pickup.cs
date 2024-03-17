using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Pickup : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnPickup;

    private Collider colliderComponent;
    public void Awake()
    {

        // Load the collider
        colliderComponent = GetComponent<Collider>();

        // Set it to be a trigger
        colliderComponent.isTrigger = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Destroy this gameObject
        Destroy(gameObject);

        // Invoke the event so designers can add GameActions
        OnPickup.Invoke();
    }
}
