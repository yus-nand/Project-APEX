using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private PickupPoolManager pickupPoolManager;

    public void SpawnPickup(PickupDropInfo pickupDropInfo, Vector3 position)
    {
        if(Random.value > pickupDropInfo.dropChance)
            return;

        pickupDropInfo.pickupData.Spawn(position, this);
    }

    public void SpawnHealthPickup(PickupData data, Vector3 position, int amount)
    {
        PooledPickup pooledPickup = pickupPoolManager.Get(data);

        if(pooledPickup == null)
            return;

        HealthPickup healthPickup = pooledPickup.gameObject.GetComponent<HealthPickup>();

        healthPickup.Initialize(position, pooledPickup.pool, amount);
    }
}