using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;    // Your 3 enemy prefabs
    public GameObject outerSphere;       // Reference to outer sphere GameObject
    public GameObject innerSphere;       // Reference to inner (no-spawn zone) sphere
    public Transform enemiesParent;
    public float spawnY;
    public void SpawnEnemies(int x)
    {
        Vector3 center = outerSphere.transform.position;
        float outerRadius = outerSphere.transform.localScale.x * 0.5f;
        float innerRadius = innerSphere.transform.localScale.x * 0.5f;

        for (int i = 0; i < x; i++)
        {
            Vector3 spawnPos = GetRandomPointInShell(center, innerRadius, outerRadius);
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(prefab, spawnPos, Quaternion.identity, enemiesParent);
            EnemyManager.EnemySpawned();
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
