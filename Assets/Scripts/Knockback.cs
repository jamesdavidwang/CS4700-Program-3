using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: Knockback.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: General script to handle when enemy or player is hit. 
*Calls the knock method from respective enemy or player.
*
****************************************************************/


public class Knockback : MonoBehaviour
{
    [SerializeField]
    float thrust;
    [SerializeField]
    float knocktime;
    [SerializeField]
    float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("PlayerHitBox")){
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if(hit != null){
                
                Vector2 forceDirection = other.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * thrust;
                hit.velocity = force;

                if(other.gameObject.CompareTag("Enemy")){
                    hit.GetComponentInParent<EnemyBehavior>().currentState = EnemyState.stagger;
                    hit.GetComponentInParent<EnemyBehavior>().Knock(hit, knocktime, damage);
                }
                if(other.gameObject.CompareTag("PlayerHitBox")){
                    if(other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger){
                        hit.GetComponentInParent<PlayerMovement>().currentState = PlayerState.stagger;
                        hit.GetComponentInParent<PlayerMovement>().Knock(hit, knocktime, damage);
                    }
                }

                
                
                
                //StartCoroutine(KnockCoroutine(hit));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D other){
        yield return new WaitForSeconds(knocktime);

        other.velocity = new Vector2();
        other.GetComponentInParent<EnemyBehavior>().currentState = EnemyState.idle;
    }
}
