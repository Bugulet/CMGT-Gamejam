using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviorManager : MonoBehaviour
{
    public GameObject toEnableOnEnd;
    public static bool AllEnemiesKilled = false;
    // Start is called before the first frame update
    void Start()
    {
        toEnableOnEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSceneManager.PlayerHealth>0 && FindObjectOfType<EnemyMovement>() == null)
        {
            toEnableOnEnd.SetActive(true);
            AllEnemiesKilled = true;
        }
        else
        {
            toEnableOnEnd.SetActive(false);
            AllEnemiesKilled = false;
        }
    }
}
