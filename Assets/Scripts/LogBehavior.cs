using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    myRigidBody.MovePosition(temp);
                    currentState = EnemyState.walking;
            }
        }
    }


}
