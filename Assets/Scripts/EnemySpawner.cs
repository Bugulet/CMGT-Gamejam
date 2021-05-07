using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyToSpawn;
    [SerializeField]
    private float SpawnRate = 1;
    [SerializeField]
    private int HowManyToSpawn = 10;
    private int currentlySpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy",0,1f/SpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlySpawned >= HowManyToSpawn)
        {
            CancelInvoke("CreateEnemy");
        }
    }

    private void CreateEnemy()
    {
        currentlySpawned++;
        Instantiate(enemyToSpawn, this.transform);
    }
}
