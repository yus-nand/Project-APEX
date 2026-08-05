using UnityEngine;

[CreateAssetMenu(fileName = "Pickup Radius Upgrade", menuName = "Game/Upgrades/Pickup Radius Upgrade")]
public class PickupRadiusUpgrade : Upgrade
{
    [SerializeField] private float pickupRadiusBuff;
    public override void Apply(GameObject player)
    {
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.IncreasePickupRadius(pickupRadiusBuff);
    }
}
