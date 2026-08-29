using UnityEngine;
[System.Serializable]
public class PickupDropInfo
{
    public PickupData pickupData;
    [Range(0, 1)]
    public float dropChance;
    public int amount;
}
