using UnityEngine;

public abstract class PickupData : ScriptableObject
{
    public abstract void Spawn(Vector3 spawnPosition, PickupSpawner spawner);
}
