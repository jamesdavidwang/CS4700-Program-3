using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMovement();
    }

    void UpdateAnimationAndMovement(){
        if(change != Vector3.zero){
            MoveCharacter();
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
