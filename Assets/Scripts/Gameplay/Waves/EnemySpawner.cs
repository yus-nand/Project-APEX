using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }
    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject enemy = enemyPool.Get();
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.Initialize(enemyPool, spawnPoints[randomIndex].position);
        // Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}