using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: Signal.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Signal scriptable object that raises a flag on objects
*that are listening to this signal. General purpose tool for
*event system.
*
****************************************************************/


[CreateAssetMenu]
public class MySignal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise(){
        for(int i = listeners.Count - 1; i >= 0; i--){
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener){
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener){
        listeners.Remove(listener);
    }
}
