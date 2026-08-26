using UnityEngine;

public abstract class PickupData : ScriptableObject
{
    [Range(0, 1)]
    public float dropChance;
    public abstract void Spawn(Vector3 spawnPosition, PickupSpawner spawner);
}
