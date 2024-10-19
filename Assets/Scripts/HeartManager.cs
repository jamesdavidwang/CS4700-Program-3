using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/***************************************************************
*file: HeartManager.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Tracks all hearts that the player has and displays the
*apporpriate sprites depending on the health of the player. 
*Transitions to the lose screen when player health is depleted.
*
****************************************************************/


public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public CharacterValue heartContainers; 
    public CharacterValue playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts(){
        for(int i = 0; i < heartContainers.initialValue; i++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts(){
        float tempHealth = playerCurrentHealth.runtimeValue / 2;

        bool allHeartsEmpty = true;

        for(int i = 0; i < heartContainers.initialValue; i++){
            if(i <= tempHealth - 1){
                //Full Heart
                hearts[i].sprite = fullHeart;
                allHeartsEmpty = false;  // At least one heart is still full

            }
            else if(i >= tempHealth){ 
                //Empty Heart
                hearts[i].sprite = emptyHeart;
            }
            else {
                //Half Heart
                hearts[i].sprite = halfHeart;
                allHeartsEmpty = false;  // At least one heart is still full
            }
        }
        if (allHeartsEmpty)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
 
}
