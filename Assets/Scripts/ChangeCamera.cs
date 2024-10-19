using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************************************
*file: ChangeCamera.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Shifts the camera on room transition, as well as shift
*player position for room transition.
*
****************************************************************/


public class ChangeCamera : MonoBehaviour
{

    public Vector3 cameraChange;
    public Vector3 playerchange;
    private Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            
            cam.position = cameraChange;

            other.transform.position += playerchange;
            
        }
    }

    


}
