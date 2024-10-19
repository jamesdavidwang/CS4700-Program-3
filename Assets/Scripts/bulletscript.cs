using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: bulletscript.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Have the bullet fire off in right or left rom the 
*cannon
*
****************************************************************/

public class bulletscript : MonoBehaviour
{
    public float speed;
    public bool right;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(right)
            rb.velocity = -transform.right * speed;
        else
            rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
