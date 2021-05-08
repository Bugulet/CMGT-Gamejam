using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSceneManager.PlayerHealth == 0)
        {
            EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i].gameObject);
            }
            Time.timeScale = 0.0f;
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void ResetHealth()
    {
        CurrentSceneManager.PlayerHealth = CurrentSceneManager.PlayerMaxHealth;
    }
}
