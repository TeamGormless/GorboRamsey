using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class MachineBase : MonoBehaviour
{
    public virtual void Awake() { }
    public virtual void Update() { }
    public virtual void OnDestroy() { }
    public virtual void DoObjectInputIntoMachine(PickupableObject p) { }
    public virtual void DoObjectInputIntoMachine(CorpseObject c) { }
    public virtual void ProcessObject(PickupableObject p) { }
    public virtual void ProcessObject(CorpseObject c) { }
    public virtual void ProcessingComplete() { }
    public virtual void OutputNewObjectFromMachine() { }
    public virtual bool CheckObjectIsValid(PickupableObject p) { return false; }
    public virtual bool CheckObjectIsValid(CorpseObject c) { return false; }
}
