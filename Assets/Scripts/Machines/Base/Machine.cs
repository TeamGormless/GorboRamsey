using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class Machine : MonoBehaviour
{    
    [Header("Ports")]
    public MachineInputPort InputPort;
    public MachineOutputPort OutputPort;

    [Header("Inputs Outputs")]
    public PickupableObject InputObject;
    public PickupableObject OutputObject;

    [Space(10.0f)]
    public float TimeToProcess;

    protected bool Processing = false;

    public virtual void Awake()
    {
        InputPort.OnObjectInput += DoObjectInputIntoMachine;
    }

    public virtual void DoObjectInputIntoMachine(PickupableObject pickupableObject)
    {
        if (Processing) {
            Debug.Log(this.gameObject.name + " is alreadying processing! (" + pickupableObject.gameObject.name + ")", this);
        }
        else {
            ProcessObject(pickupableObject);
        }
    }

    public virtual void ProcessObject(PickupableObject pickupableObject)
    {
        if (CheckObjectIsValid(pickupableObject)) {
            OutputNewObjectFromMachine();
            Destroy(pickupableObject.gameObject);
        }
    }

    private void OutputNewObjectFromMachine()
    {
        PickupableObject p = GameObject.Instantiate(OutputObject).GetComponent<PickupableObject>();
        p.transform.position = InputPort.transform.position;
        p.Throw(InputPort.transform.forward);
    }

    public virtual bool CheckObjectIsValid(PickupableObject pickupableObject)
    {
        if (pickupableObject.gameObject.name == InputObject.gameObject.name)
            return true;
        else
            return false;
    }


    public virtual void OnDestroy()
    {
        InputPort.OnObjectInput -= DoObjectInputIntoMachine;
    }
}
