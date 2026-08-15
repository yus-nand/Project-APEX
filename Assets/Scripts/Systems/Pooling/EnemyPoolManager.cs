using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] private List<EnemyPoolEntry> pools = new();
    public PooledEnemy Get(EnemyData data)
    {
        foreach(EnemyPoolEntry entry in pools)
        {
            if(entry.enemyData == data)
            {
                return new PooledEnemy{gameObject = entry.pool.Get(), pool = entry.pool};
            }
        }
        Debug.LogError($"No pool configured for enemy: {data.enemyName}");
        return null;
    }
    public void AddPoolEntry(EnemyPoolEntry poolEntry)
    {
        if(poolEntry == null)
            return;
        
        pools.Add(poolEntry);
    }
}
