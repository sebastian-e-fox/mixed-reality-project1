using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public int toSpawn = 0;
    
    public EnemySpawner spawner;

    [Header("Wave System")]
    public int totalEnemies;
    public int waveNumber = 0;


    private void Start()
    {
        spawner = GetComponent<EnemySpawner>();
    }

    public void Update()
    {
        totalEnemies = enemiesAlive;
        if (enemiesAlive == 0 && waveNumber < 3)
        {
            toSpawn += 5;
            SpawnNewWave();
        }
    }

    public static void EnemySpawned()
    {
        enemiesAlive++;
    }

    public static void EnemyDied()
    {
        enemiesAlive--;
        enemiesAlive = Mathf.Max(enemiesAlive, 0); // prevent negatives
    }

    public void SpawnNewWave()
    {
        spawner.SpawnEnemies(toSpawn);
        waveNumber++;
    }

}

