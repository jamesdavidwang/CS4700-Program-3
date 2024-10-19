using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: CameraMovement.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Moves the camera to each room, following the Player
*
****************************************************************/

public class CameraMovement : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position){
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }   
    }
}
