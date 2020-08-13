using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class CharacterPickupController : MonoBehaviour
{
    private const float VERTICAL_THROW_POWER = 0.10f;

    public PickupableObject PickedUpObject { get; private set; }

    public KeyCode PickUpKey;
    public float ThrowForce;

    private Vector3 holdObjectOffset;
    private CharacterPickupTrigger characterPickupTrigger;


    private void Start()
    {
        holdObjectOffset = Vector3.up * 2;
        characterPickupTrigger = GetComponentInChildren<CharacterPickupTrigger>();
    }

    private void Update()
    {
        if (CheckHandsFull())
            DoHoldObject();

        DoPickUpObjectKeyDown();
    }
    private bool CheckHandsFull()
    {
        if (PickedUpObject)
            return true;
        else
            return false;
    }

    private void DoHoldObject()
    {
        PickedUpObject.transform.position = this.transform.position + holdObjectOffset;
        PickedUpObject.transform.rotation = this.transform.rotation;
    }

    private void DoPickUpObjectKeyDown()
    {
        if (Input.GetKeyDown(PickUpKey)) {

            if (CheckHandsFull())
                PutDownObject(PickedUpObject);
            else {
                PickupableObject p = characterPickupTrigger.GetPickupable();
                if (p) {
                    PickUpObject(p);
                }
            }
        }
    }

    private void PickUpObject(PickupableObject p)
    {
        PickedUpObject = p.Pickup();
    }

    private void PutDownObject(PickupableObject p)
    {
        PickedUpObject = null;
        
        p.Putdown();

        Vector3 throwVector = new Vector3(
            transform.forward.x, 
            transform.forward.y + VERTICAL_THROW_POWER, 
            transform.forward.z);

        p.Throw(throwVector * ThrowForce);
    }


}
