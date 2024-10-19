using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/***************************************************************
*file: EnemyBehavior.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Script to handle all enemy behavior. Includes 
*statemachine and script to handle when hit, as well as when 
*health is depleted.
*
****************************************************************/

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
            //SceneManager.LoadScene("WinScene");
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
