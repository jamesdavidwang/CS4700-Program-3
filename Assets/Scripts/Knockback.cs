using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    float thrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            Rigidbody2D enemy = other.GetComponentInParent<Rigidbody2D>();
            if(enemy != null){
                enemy.GetComponentInParent<EnemyBehavior>().currentState = EnemyState.stagger;
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy){
        Vector2 forceDirection = enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        enemy.velocity = force;
        yield return new WaitForSeconds(.3f);

        enemy.velocity = new Vector2();
        enemy.GetComponentInParent<EnemyBehavior>().currentState = EnemyState.idle;
    }
}
