using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walking,
    attack,
    stagger
}

public class EnemyBehavior : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private Rigidbody2D rb;

    public void Knock(Rigidbody2D other, float knocktime){
        StartCoroutine(KnockCoroutine(other, knocktime));
    }
    private IEnumerator KnockCoroutine(Rigidbody2D other, float knocktime){
            yield return new WaitForSeconds(knocktime);

            other.velocity = new Vector2();
            currentState = EnemyState.idle;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
