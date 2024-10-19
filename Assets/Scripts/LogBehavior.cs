using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: LogBehavior.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Behavior script of the log enemy. Inherits the
*EnemyBehavior class and defines the log to chase the Player when
*in range.
*
****************************************************************/


public class LogBehavior : EnemyBehavior
{
    private Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    public Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
    }

    
    void FixedUpdate()
    {
        checkDistance();
    }

    void checkDistance(){
        if(Vector2.Distance(target.position, transform.position) <= chaseRadius 
            && Vector2.Distance(target.position, transform.position) >= attackRadius ){
                if(currentState == EnemyState.idle || currentState == EnemyState.walking && currentState != EnemyState.stagger){
                    Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                    changeAnim(temp - (Vector2)transform.position);
                    myRigidBody.MovePosition(temp);
                    currentState = EnemyState.walking;
                    anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector2.Distance(target.position, transform.position) > chaseRadius ){
            anim.SetBool("wakeUp", false);
        }
    }

    private void SetAnimFloat(Vector2 setVector){
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction){
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if (direction.x >0){
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y <0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

}
