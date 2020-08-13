using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mincer : MachineObject
{
    [Header("Processing")]
    public CorpseObject InputObject;
    public MeatObject OutputObject;

    public override void DoObjectInputIntoMachine(PickupableObject p)
    {
        base.DoObjectInputIntoMachine(p);
        CorpseObject c = (CorpseObject)p;
        if (CheckObjectIsValid(c))
            ProcessObject(c);
    }

    public override bool CheckObjectIsValid(CorpseObject c)
    {
        if (c.Spieces == InputObject.Spieces)
            return true;
        else
            return false;
    }

    public override void ProcessObject(CorpseObject c)
    {
        base.ProcessObject(c);
        if (Processing) {
            Debug.Log(this.gameObject.name + " is already processing!");
        }
        else {
            Destroy(c.gameObject);
            Processing = true;
        }
    }

    public override void OutputNewObjectFromMachine()
    {
        base.OutputNewObjectFromMachine();
        MeatObject m = Instantiate(OutputObject);
        m.transform.position = OutputPort.transform.position;
        m.Throw(OutputObject.transform.forward * 5);
    }
}
