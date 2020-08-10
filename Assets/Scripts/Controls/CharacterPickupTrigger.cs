using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickupTrigger : MonoBehaviour
{
    private List<PickupableObject> pickupablesInTrigger;

    private void Start()
    {
        pickupablesInTrigger = new List<PickupableObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PickupableObject p = other.gameObject.GetComponent<PickupableObject>();
        if (p) {
            pickupablesInTrigger.Add(p);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickupableObject p = other.gameObject.GetComponent<PickupableObject>();
        if (p) {
            pickupablesInTrigger.Remove(p);
        }
    }

    public PickupableObject GetPickupable()
    {
        if (pickupablesInTrigger.Count > 0) {
            return pickupablesInTrigger[0];
        }
        else
            return null;
    }
}
