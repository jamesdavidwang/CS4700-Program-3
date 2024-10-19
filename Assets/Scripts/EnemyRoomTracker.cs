using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

/***************************************************************
*file: EnemyRoomTracker.cs
*author: Ryan Yang and James Wang
*class: CS 4700 – Game Development
*assignment: program 3
*date last modified: 10/18/2024
*
*purpose: Tracks the status of all enemies in the final room.
*Displays the win screen once all enemies are defeated.
*
****************************************************************/


public class EnemyRoomTracker : MonoBehaviour
{
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemies.Length; i++){
            enemies[i].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AreAllEnemiesDefeated()){
            
            Debug.Log("All enemies defeated");
            SceneManager.LoadScene("WinScene");
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        return enemies.All(enemy => !enemy.activeSelf);
    }
}
