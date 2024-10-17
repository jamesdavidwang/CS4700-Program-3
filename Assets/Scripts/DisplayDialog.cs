using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if(Input.GetKey(KeyCode.Space) && playerInRange){
        //     if(dialogBox.activeInHierarchy){
        //         dialogBox.SetActive(false);
        //     }
        //     else {
        //         dialogBox.SetActive(true);
        //         dialogText.text = dialog;
        //     }
        // }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
            dialogBox.SetActive(true);
                dialogText.text = dialog;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
            if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
            }
        }
    }
}
