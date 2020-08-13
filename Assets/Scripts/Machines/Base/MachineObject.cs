using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class MachineObject : MachineBase
{    
    [Header("Ports")]
    public MachineInputPort InputPort;
    public MachineOutputPort OutputPort;

    public float TimeToProcess;

    protected bool Processing = false;
    protected float processingTime = 0;

    public override void Awake()
    {
        InputPort.OnObjectInput += DoObjectInputIntoMachine;
    }

    public override void Update()
    {
        base.Update();
        if (Processing) {
            processingTime += Time.deltaTime;
            
            if (processingTime > TimeToProcess) {
                Processing = false;
                processingTime = 0;
                ProcessingComplete();
            }
        }
    }

    public override void OnDestroy()
    {
        InputPort.OnObjectInput -= DoObjectInputIntoMachine;
    }

    public override void ProcessingComplete()
    {
        base.ProcessingComplete();
        OutputNewObjectFromMachine();
    }
}
