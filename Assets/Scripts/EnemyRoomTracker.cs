using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class EnemyRoomTracker : MonoBehaviour
{
    public GameObject[] enemies;
    bool enemiesDefeated;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemies.Length; i++){
            enemies[i].SetActive(true);
        }
        enemiesDefeated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(AreAllEnemiesDefeated()){
            enemiesDefeated = true;
            Debug.Log("All enemies defeated");
            SceneManager.LoadScene("WinScene");
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        return enemies.All(enemy => !enemy.activeSelf);
    }
}
