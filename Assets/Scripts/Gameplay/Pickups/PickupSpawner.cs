using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool healthPickupPool;
    public void SpawnHealthPickup(Vector3 position, int amount)
    {
        Debug.Log("PickupSpawner: Spawning HealthPickups");
        GameObject healthPickupGO = healthPickupPool.Get();
        HealthPickup healthPickup = healthPickupGO.GetComponent<HealthPickup>();
        healthPickup.Initialize(position, healthPickupPool, amount);
    }
}
