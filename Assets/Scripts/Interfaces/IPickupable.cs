using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    PickupableObject Pickup();
    PickupableObject Putdown();
    PickupableObject Throw(Vector3 v);
}
