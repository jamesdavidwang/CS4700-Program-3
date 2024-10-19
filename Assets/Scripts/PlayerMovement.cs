using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************
*file: PlayerMovement.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Main Controller for the Player
*
****************************************************************/

public enum PlayerState{
    idle,
    walk,
    attack,
    interact, 
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator anim;
    public CharacterValue currentHealth;
    public MySignal playerHealthSignal;

    

    // Start is called before the first frame update
    void Start() {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", -1);
    }

    // Update is called once per frame
    void Update() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger){
            StartCoroutine(AttackCo());
        }

        else if(currentState == PlayerState.walk){
            UpdateAnimation();
        }
    }

    void FixedUpdate() {
        // Handle movement in FixedUpdate for smooth physics-based movement
        if (change != Vector3.zero && currentState == PlayerState.walk) {
            MoveCharacter();
        }
    }

    private IEnumerator AttackCo(){
        anim.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("Attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimation(){
        if(change != Vector3.zero){
            anim.SetFloat("MoveX", change.x);
            anim.SetFloat("MoveY", change.y);
            anim.SetBool("Moving", true);
        }
        else{
            anim.SetBool("Moving", false);
        }
    }

    void MoveCharacter(){
        change.Normalize();
        myRigidBody.MovePosition(
            transform.position + speed * Time.deltaTime * change
        );
    }

    public void Knock(Rigidbody2D other, float knocktime, float damage){
        currentHealth.runtimeValue -= damage;
        playerHealthSignal.Raise();
        //Debug.Log(currentHealth.runtimeValue);
        if(currentHealth.runtimeValue > 0){
            StartCoroutine(KnockCoroutine(other, knocktime));
        }
        else{
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D other, float knocktime){
            yield return new WaitForSeconds(knocktime);

            myRigidBody.velocity = new Vector2();
            currentState = PlayerState.walk;
            //myRigidBody.velocity = Vector2.zero;
    }

}
