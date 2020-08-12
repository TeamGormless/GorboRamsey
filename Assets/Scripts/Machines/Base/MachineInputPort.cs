
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInputPort : MonoBehaviour
{
    public delegate void InputEvent(PickupableObject pickupableObject);
    public event InputEvent OnObjectInput;

    public void OnTriggerEnter(Collider other)
    {
        PickupableObject p = other.GetComponent<PickupableObject>();
        if (p)
            OnObjectInput?.Invoke(p);
    }
}
