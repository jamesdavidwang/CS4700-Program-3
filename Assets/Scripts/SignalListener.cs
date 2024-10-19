using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/***************************************************************
*file: SignalListnener.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Listens to the Signal scriptable object in order to
*coordinate with the event system. General purpose.
*
****************************************************************/

public class SignalListener : MonoBehaviour
{
    public MySignal signal;
    public UnityEvent signalEvent;
    public void OnSignalRaised(){
        signalEvent.Invoke();
    }

    private void OnEnable(){
        signal.RegisterListener(this);
    }

    private void OnDisable(){
        signal.DeRegisterListener(this);
    }

}
