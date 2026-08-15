using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPoolManager enemyPoolManager;
    [Header("Spawner Settings")]
    // [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    
    public void SpawnEnemy(EnemyData data)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        PooledEnemy pooledEnemy = enemyPoolManager.Get(data);
        if(pooledEnemy == null)
            return;

        GameObject enemy = pooledEnemy.gameObject;
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.Initialize(pooledEnemy.pool, spawnPoints[randomIndex].position);
    }
}