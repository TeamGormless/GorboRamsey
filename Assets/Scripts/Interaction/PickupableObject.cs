using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour, IPickupable
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public PickupableObject Pickup()
    {
        rb.useGravity = false;
        return this;
    }

    public PickupableObject Putdown()
    {
        rb.useGravity = true;
        return this;
    }

    public PickupableObject Throw(Vector3 v)
    {
        rb.useGravity = true;
        rb.AddExplosionForce(300, v, 30);
        return this;
    }
}
