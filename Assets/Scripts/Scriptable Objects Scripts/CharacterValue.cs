using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: CharacterValue.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Scriptable object for holding a float value attribute
*for any object. Has initial value and changable runtime value
*
****************************************************************/


[CreateAssetMenu]
public class CharacterValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [NonSerialized]
    public float runtimeValue;

    public void OnAfterDeserialize(){
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize(){

    }
}
