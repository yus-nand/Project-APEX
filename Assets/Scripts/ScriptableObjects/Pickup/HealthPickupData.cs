using UnityEngine;

[CreateAssetMenu(fileName = "HealthPickupData", menuName = "Game/Pickup/Health Pickup")]
public class HealthPickupData : PickupData
{
    [SerializeField] private int healAmount = 2;
    public override void Spawn(Vector3 spawnPosition, PickupSpawner spawner)
    {
        Debug.Log("HealthPickupData: Spawning HealthPickup");
        spawner.SpawnHealthPickup(this, spawnPosition, healAmount);
    }
}
