using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPoolManager enemyPoolManager;
    [SerializeField] private ObjectPool xpGemPool;
    [SerializeField] private ObjectPool deathParticlePool;
    [SerializeField] private ObjectPool enemyProjectilePool;
    [Header("Spawner Settings")]
    // [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    
    public void SpawnEnemy(EnemyData data)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        SpawnEnemyAt(data, spawnPoints[randomIndex].position);
    }
    public  void SpawnEnemyAt(EnemyData data, Vector3 position)
    {
        PooledEnemy pooledEnemy = enemyPoolManager.Get(data);
        if(pooledEnemy == null)
            return;

        GameObject enemy = pooledEnemy.gameObject;
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.Initialize(pooledEnemy.pool, position, data, xpGemPool, deathParticlePool, enemyProjectilePool);
    }
}