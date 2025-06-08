using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public int totalEnemies;

    public void Update()
    {
        totalEnemies = enemiesAlive;
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
}

