using System.Collections.Generic;
using UnityEngine;

public class PickupPoolManager : MonoBehaviour
{
    [SerializeField] private List<PickupPoolEntry> pools = new();
    public PooledPickup Get(PickupData data)
    {
        foreach(PickupPoolEntry entry in pools)
        {
            if(entry.data == data)
            {
                return new PooledPickup { gameObject = entry.pool.Get(), pool = entry.pool };
            }
        }
        Debug.LogError($"No pool configured for{data}");
        return null;
    }
}
