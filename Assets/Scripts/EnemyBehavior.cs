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
    public CharacterValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    private Rigidbody2D rb;

    public void Knock(Rigidbody2D other, float knocktime, float damage){
        StartCoroutine(KnockCoroutine(other, knocktime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCoroutine(Rigidbody2D other, float knocktime){
            yield return new WaitForSeconds(knocktime);

            other.velocity = new Vector2();
            currentState = EnemyState.idle;
    }

    private void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            this.gameObject.SetActive(false);
        }
    }

    void Awake(){
        health = maxHealth.initialValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
