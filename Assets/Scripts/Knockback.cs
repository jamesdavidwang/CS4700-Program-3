using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    float thrust;
    [SerializeField]
    float knocktime;

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
                    hit.GetComponentInParent<EnemyBehavior>().Knock(hit, knocktime);
                }
                if(other.gameObject.CompareTag("PlayerHitBox")){
                    hit.GetComponentInParent<PlayerMovement>().currentState = PlayerState.stagger;
                    hit.GetComponentInParent<PlayerMovement>().Knock(hit, knocktime);
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
