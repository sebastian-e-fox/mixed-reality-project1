using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;    // Your 3 enemy prefabs
    public GameObject outerSphere;       // Reference to outer sphere GameObject
    public GameObject innerSphere;       // Reference to inner (no-spawn zone) sphere
    public int enemiesToSpawn = 10;
    public float spawnY = -1.295f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        Vector3 center = outerSphere.transform.position;
        float outerRadius = outerSphere.transform.localScale.x * 0.5f;
        float innerRadius = innerSphere.transform.localScale.x * 0.5f;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPos = GetRandomPointInShell(center, innerRadius, outerRadius);
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(prefab, spawnPos, Quaternion.identity);
        }
    }

    Vector3 GetRandomPointInShell(Vector3 center, float innerRadius, float outerRadius)
    {
        Vector3 point;
        float dist;

        do
        {
            Vector2 randomCircle = Random.insideUnitCircle * outerRadius;
            dist = randomCircle.magnitude;

            if (dist >= innerRadius)
            {
                point = new Vector3(randomCircle.x, spawnY, randomCircle.y);
                return center + point;
            }
        }
        while (true);
    }
}
