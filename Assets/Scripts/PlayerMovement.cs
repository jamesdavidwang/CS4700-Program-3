using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator anim;

    

    // Start is called before the first frame update
    void Start() {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButtonDown("Attack") && currentState != PlayerState.attack){
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
        myRigidBody.MovePosition(
            transform.position + speed * Time.deltaTime * change
        );
    }
}
